﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TruphoxGP
{
    public partial class Post : System.Web.UI.Page
    {
        DAL mydal;
        public int postID { get; set; }
        public string postType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            postID = Convert.ToInt32(Request.QueryString["postID"].ToString());
            string postType = Request.QueryString["postType"].ToString();
            Security sec = new Security();

            if (postType == "artwork")
            {
                //make artwork panel visible
                pnlArtwork.Visible = true;
                loadArt(postID);
            }

            if (postType == "writing")
            {
                //make Literature panel visible
                pnlWriting.Visible = true;
                loadWriting(postID);
            }

            if (postType == "photography")
            {
                //make photography panel visible
                pnlPhotography.Visible = true;
                loadPhotography(postID);
            }

            if (postType == "video")
            {
                //make video panel visible
                pnlVideo.Visible = true;
                loadVideo(postID);
            }

            if (!IsPostBack)
            {
                loadUser(postID);
                loadLikes(postID);

                if(sec.username != null)
                {
                    pnlEditPost.Visible = true;
                }

            }            
        }
        private void loadUser( int PostID)
        {
            Security sec = new Security();
            mydal = new DAL("spReadPost");
            mydal.addParm("postID", PostID.ToString());
            DataSet ds = mydal.getDataSet();

            lblUsername.Text = ds.Tables[0].Rows[0]["username"].ToString();
        }

        private void loadArt(int PostID)
        {
            //load post
            mydal = new DAL("spReadArt");
            mydal.addParm("postID", PostID.ToString());
            DataSet ds = mydal.getDataSet();

            lblPostTitle.Text = ds.Tables[0].Rows[0]["postTitle"].ToString();
            lblPostSubtitle.Text = ds.Tables[0].Rows[0]["postSubTitle"].ToString();
            imgArtwork.ImageUrl = ds.Tables[0].Rows[0]["artLink"].ToString();
        }

        private void loadPhotography(int PostID)
        {
            //load post
            mydal = new DAL("spReadPhotography");
            mydal.addParm("postID", PostID.ToString());
            DataSet ds = mydal.getDataSet();

            lblPostTitle.Text = ds.Tables[0].Rows[0]["postTitle"].ToString();
            lblPostSubtitle.Text = ds.Tables[0].Rows[0]["postSubTitle"].ToString();
            imgPhotography.ImageUrl = ds.Tables[0].Rows[0]["photoLink"].ToString();
        }

        private void loadWriting(int PostID)
        {
            //load post
            mydal = new DAL("spReadWriting");
            mydal.addParm("postID", PostID.ToString());
            DataSet ds = mydal.getDataSet();

            lblPostTitle.Text = ds.Tables[0].Rows[0]["postTitle"].ToString();
            lblPostSubtitle.Text = ds.Tables[0].Rows[0]["postSubTitle"].ToString();
            lblWriting.Text = ds.Tables[0].Rows[0]["writingText"].ToString();
        } 

        private void loadVideo(int PostID)
        {
            //load post
            mydal = new DAL("spReadVideo");
            mydal.addParm("postID", PostID.ToString());
            DataSet ds = mydal.getDataSet();

            lblPostTitle.Text = ds.Tables[0].Rows[0]["postTitle"].ToString();
            lblPostSubtitle.Text = ds.Tables[0].Rows[0]["postSubTitle"].ToString();
            //postVideo. = ds.Tables[0].Rows[0]["videoLink"].ToString();
        }

        private void loadLikes(int PostID)
        {
            mydal = new DAL("spReadLike");
            mydal.addParm("postID", PostID.ToString());
            DataSet ds = mydal.getDataSet();

            lblLikes.Text = ds.Tables[0].Rows[0]["count"].ToString() + " Likes";
        }


        protected void btnLike_Click(object sender, EventArgs e)
        {
            Security mySecurity = new Security();

            if (mySecurity.isLoggedIn == true)
            {
                mydal = new DAL("spCreateLike");
                mydal.addParm("username", mySecurity.username);
                mydal.addParm("postID", postID.ToString());
                mydal.execNonQuery();
            }
            else
            {

            }
            loadLikes(postID);            
        }

        protected void lnkBtnUsername_Click(object sender, EventArgs e)
        {
            Security mySecurity = new Security();
            string viewUser = lblUsername.Text; 

            if(viewUser != mySecurity.username)
            {
                Response.Redirect("viewProfile.aspx?followedUser=" + viewUser);
            }
            else
            {
                Response.Redirect("Profile.aspx");
            }
          
        }

        protected void btnEditPost_Click(object sender, EventArgs e)
        {
            int PostID = postID;
            string PostType = postType;
            Security mySecurity = new Security();
            string viewUser = lblUsername.Text;
            if (viewUser != mySecurity.username)
            {
                
            }
            else
            {
                if (PostType != null)
                {
                    switch (PostType)
                    {
                        case "artwork":
                            Response.Redirect("submitArt?postID=" + postID);
                            break;
                        case "photography":
                            Response.Redirect("submitPhotography?postID=" + postID);
                            break;
                        case "writing":
                            Response.Redirect("submitLit?postID=" + postID);
                            break;
                        case "video":
                            Response.Redirect("submitVideo?postID=" + postID);
                            break;
                    }
                }
            }
        }

        protected void btnDeletePost_Click(object sender, EventArgs e)
        {
            Security mySecurity = new Security();
            string viewUser = lblUsername.Text;

            if (viewUser != mySecurity.username)
            {
               
            }
            else
            {
                mydal = new DAL("spDeletePost");
                mydal.addParm("postID", postID.ToString());
                mydal.execNonQuery();
            }
        }
    }
}