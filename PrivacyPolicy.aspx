﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
 
         $(document).ready(function () {
             $("div.bhoechie-tab-menu>div.list-group>a").click(function (e) {
                 e.preventDefault();
                 $(this).siblings('a.active').removeClass("active");
                 $(this).addClass("active");
                 var index = $(this).index();
                 $("div.bhoechie-tab>div.bhoechie-tab-content").removeClass("active");
                 $("div.bhoechie-tab>div.bhoechie-tab-content").eq(index).addClass("active");
             });
         });
		</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
          <div class="row"> 
            <div class="col-md-12">
              <h3 class="title text-theme-colored text-center ">Privacy Policy</h3>
            </div><div class="separator">
  <i class="fa fa-cog fa-spin"></i>
</div>
          </div>
        
	<div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 bhoechie-tab-container">
            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 bhoechie-tab-menu">
              <div class="list-group">
                <a href="#" class="list-group-item active text-center">
                 Lets Begin
                </a>
                <a href="#" class="list-group-item text-center">
               Login & Password
                </a>
                <a href="#" class="list-group-item text-center">
               Profile Management
                </a>
                <a href="#" class="list-group-item text-center">
               Photographs
                </a>
                <a href="#" class="list-group-item text-center">
          Searching and Matching
                </a>
                    <a href="#" class="list-group-item text-center">
       Contacting & responding 
                </a>
                   <a href="#" class="list-group-item text-center">
    Chat
                </a>
                   <a href="#" class="list-group-item text-center">
      Memberships 
                </a>
                   <a href="#" class="list-group-item text-center">
       Payment Options
                </a>
                     <a href="#" class="list-group-item text-center">
        Alerts
                </a>
                     <a href="#" class="list-group-item text-center">
     Technical issues
                </a>
                    <a href="#" class="list-group-item text-center">
 Privacy and Security Tips
                </a>
              </div>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 bhoechie-tab">
                <!-- Lets Bigin section -->
                <div class="bhoechie-tab-content active">
                      <div class="panel-group" id="accordion">
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">How Can I register on swapnpurti.in?
</a>
        </h4>
      </div>
      <div id="collapse1" class="panel-collapse collapse in">
        <div class="panel-body">All you need to do is, fill out the required information in the Registration Form as accurately as possible and click on the 'Submit' button. </div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">Can I register on behalf of a relative or a friend?
</a>
        </h4>
      </div>
      <div id="collapse2" class="panel-collapse collapse">
        <div class="panel-body">Yes you can! In the Registration Form, you can specify your relationship with the person on whose behalf you are registering.</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">How much do I have to pay to register on swapnpurti.in?
</a>
        </h4>
      </div>
      <div id="collapse3" class="panel-collapse collapse">
        <div class="panel-body">Registration on swapnpurti.in  is FREE. Register now and create your Profile.</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">What are the benefits of registering on swapnpurti.in?

</a>
        </h4>
      </div>
      <div id="collapse4" class="panel-collapse collapse">
        <div class="panel-body">You can avail of the following services as a free Member:-
            <ul>
<li>Create and manage your Profile on swapnpurti.in </li>
<li>Add Photos to your Profile</li>
<li>Add your Partner Preferences the kind of person you are looking for
Search and View Profiles without restrictions</li>
<li>Express Interest in other Members and respond to Members who Express Interest in you</li>
<li>Receive Chat requests and Chat with Members who are online</li>
<li>Add your Horoscope and also create your Astro Sketch</li>
<li>See Members who Viewed your Profile, Members who Expressed Interest in you and Members who match your Partner Preferences. </li>
<li>Shortlist a Profile that you like. Register Now with swapnpurti.in and create your Profile.</li>
                </ul>
</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse5">How long does it take to register and create a Profile on swapnpurti.in?
</a>
        </h4>
      </div>
      <div id="collapse5" class="panel-collapse collapse">
        <div class="panel-body">Registration and Profile creation on swapnpurti.in can be completed in less than 8 minutes. In three easy steps you can register with swapnpurti.in and create your Profile.
</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse6">The form seems to be a bit lengthy. Do I need to fill it entirely?
</a>
        </h4>
      </div>
      <div id="collapse6" class="panel-collapse collapse">
        <div class="panel-body">We understand that it may become tedious for you to fill in a long form in one go. However, matrimonial decision are important decisions and hence one should convey detailed information about oneself to Interested Members. The more information you provide about yourself the more likely you are to be contacted by other Members of swapnpurti.in. So please do take the time and effort to complete your Profile. Register Now with swapnpurti.in and create your Profile.

</div>
      </div>
    </div>

    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse8">While registering and creating a Profile, can I avoid providing information in the compulsory fields?

</a>
        </h4>
      </div>
      <div id="collapse8" class="panel-collapse collapse">
        <div class="panel-body">No. All the compulsory fields have to be filled in order to complete the registration and matrimonial Profile creation process. These compulsory fields provide essential information about you to other Members who view your Profile.
Register Now with swapnpurti.in and create your Profile.

</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse9">Can I specify more than one email while registering with swapnpurti.in?

</a>
        </h4>
      </div>
      <div id="collapse9" class="panel-collapse collapse">
        <div class="panel-body">No. You may specify only one email while registering. You can however change your email address later if you wish.
</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse10">My Religion/Caste/Mother tongue/Profession is not listed in the Registration form. What should I do?

</a>
        </h4>
      </div>
      <div id="collapse10" class="panel-collapse collapse">
        <div class="panel-body">swapnpurti.in has tried to be as comprehensive as possible while creating the many lists being used in the Registration form. However, it is possible that your particular religion / caste, mother tongue, education, profession etc may not be represented here.
In such a case we request that you use the 'Other' option provided to you. Also, you can send an email to customercare@swapnpurti.in clearly listing the new addition you would like us to make to the Registration form. While we do not guarantee that your suggestion will be Accepted, we will try our best to ensure that it does.
</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse11">The registration form requires information about my time of birth and city of birth. What do I do if I am not sure of these details?

</a>
        </h4>
      </div>
      <div id="collapse11" class="panel-collapse collapse">
        <div class="panel-body">These details are usually of Interest for matching horoscopes. You may leave these details blank if you are not sure of answers to these questions. However, we recommend that you try and find these answers and enter them later. This information will be useful in generating automatic horoscopes for better matrimonial matches.
</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse12">What is the advantage of verifying my phone number? How can I do it?

</a>
        </h4>
      </div>
      <div id="collapse12" class="panel-collapse collapse">
        <div class="panel-body">Verifying your phone number helps you get more responses, since it builds trust, and adds authenticity to your Profile.
You can Verify your phone number by using either our Interactive Voice Response System or via SMS in case you have provided a mobile number as your contact number.
</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse13">What is a Profile ID? Is it important?

</a>
        </h4>
      </div>
      <div id="collapse13" class="panel-collapse collapse">
        <div class="panel-body">A Profile ID is automatically generated by swapnpurti.in and uniquely identifies your Profile on swapnpurti.in. Every Member of swapnpurti.in has a unique Profile ID. Other Members can also search for your Profile using the Profile ID search feature.</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse14">Are there any specific DOs and DON'Ts while creating a matchmaking Profile on swapnpurti.in?

</a>
        </h4>
      </div>
      <div id="collapse14" class="panel-collapse collapse">
        <div class="panel-body">Do not use your Profile to display your contact details. Do not make commercial use of it and do not include content that is vulgar, pornographic or racist. See our terms of use / service agreement for more details of what type of content is prohibited on swapnpurti.in.
Be as detailed as possible while creating your Profile. After your Profile is activated, be sure to fill in the Partner Profile and also to upload a photograph. The more information you add, the more your chances of finding a partner.
Register Now with swapnpurti.in and create your Profile.
</div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse15">While registering, I got an error message that says that my email is already registered with swapnpurti.in and that I must specify another email. Why does this happen?

</a>
        </h4>
      </div>
      <div id="collapse15" class="panel-collapse collapse">
        <div class="panel-body">Every Profile posted on swapnpurti.in is associated with only one unique email. You may have received this error message because you or someone else has already posted a Profile using this email. If you think your email is being used by someone else, please send us an email from the address that is under contention and let us know.
        </div>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h4 class="panel-title">
          <a data-toggle="collapse" data-parent="#accordion" href="#collapse16">Why should I set my Partner Preferences?</a>
        </h4>
      </div>
      <div id="collapse16" class="panel-collapse collapse">
        <div class="panel-body">Setting your  Partner Preferences tells us more about the kind of partner you are looking for and helps swapnpurti.in suggest better matching Profiles for you. Also, your Preferences helps other Members decide whether you be interested if they were to contact you.
        </div>
      </div>
    </div>
  </div> 
</div>
              
                <!-- Login & Password section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion1">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion1" href="#collapse17">How do I Login and Logout from swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse17" class="panel-collapse collapse">
                            <div class="panel-body">The Login and Logout options are found at the top right corner of the swapnpurti.in website. 
                               </div>
                             </div>
                            </div>
                                <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion1" href="#collapse18">Can I be permanently logged into my account to avoid logging in everytime I visit swapnpurti.in?</a>
                                 </h4>
                           </div>
                         <div id="collapse18" class="panel-collapse collapse">
                            <div class="panel-body">Yes, you can be logged into your account permanently by selecting the “Stay Signed in” option next to the “Sign in” button.
<br />NOTE: We recommend that you do NOT use the ‘Stay Signed in’ feature if you are signing in from a shared computer.


                               </div>
                             </div>
                            </div>
                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion1" href="#collapse19">Can other Members of swapnpurti.in come to know when I am logged into swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse19" class="panel-collapse collapse">
                            <div class="panel-body">Yes. The  Who is Online feature lists Members who are currently online. This feature helps online Members to get noticed.
                                </div>
                             </div>
                            </div>
                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion1" href="#collapse20">I forgot my password, what should I do? How can I login to the swapnpurti.in Matchmaking Service?
</a>
                                 </h4>
                           </div>
                         <div id="collapse20" class="panel-collapse collapse">
                            <div class="panel-body">If you have forgotten your password, we can send it to you via email.  When enter your email; you will receive your Login and Password credentials immediately.


                               </div>
                             </div>
                            </div>
                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion1" href="#collapse21">How can I change my password?
</a>
                                 </h4>
                           </div>
                         <div id="collapse21" class="panel-collapse collapse">
                            <div class="panel-body"> Visit the ‘My Settings’ page and change your password. The ‘My Settings’ page can be accessed by clicking on your display name on the top right, after you login.

                               </div>
                             </div>
                            </div>
                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion1" href="#collapse22">How can I change my contact information?
</a>
                                 </h4>
                           </div>
                         <div id="collapse22" class="panel-collapse collapse">
                            <div class="panel-body">By edit your contact information.
                               </div>
                             </div>
                            </div>
                         </div>
                    </div>
    
                <!-- Profile Management Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion2">
                           <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse23">How can I create a new Profile on swapnpurti.in?

</a>
                                 </h4>
                           </div>
                         <div id="collapse23" class="panel-collapse collapse">
                            <div class="panel-body">Posting your Profile on swapnpurti.in is easy and completely FREE of cost. All you need to do is fill in our FREE Registration form.
                               </div>
                             </div>
                            </div>
                                     <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse24">How do I edit my swapnpurti.in Profile?

</a>
                                 </h4>
                           </div>
                         <div id="collapse24" class="panel-collapse collapse">
                            <div class="panel-body"> You can also access this page by clicking on ‘Edit Profile’ from your My AnuvaaMatrimony page.
                               </div>
                             </div>
                            </div>
                                     <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse25">How can I change my Display Name on my Profile?

</a>
                                 </h4>
                           </div>
                         <div id="collapse25" class="panel-collapse collapse">
                            <div class="panel-body">You can change your Display Name and change your Display Name settings from the Privacy Options page inside ‘Settings’.
If you prefer not to display your full name on your Profile, you can choose to display your First Name and initial of last name e.g. Sonika M or you can choose to display a custom username

                               </div>
                             </div>
                            </div>
                                     <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse26">Can I change any/all of my Profile information from the Edit Profile page?

</a>
                                 </h4>
                           </div>
                         <div id="collapse26" class="panel-collapse collapse">
                            <div class="panel-body">You can change most of the information in your Profile. However, there are some items (e.g. your date of birth, gender, marital status and religion) that can be changed only in exceptional circumstances. To change these fields please write to Customer Relations providing a valid reason for the change.

                               </div>
                             </div>
                            </div>
                                     <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse27">Can I change my email after registering with swapnpurti.in and creating my Profile?
</a>
                                 </h4>
                           </div>
                         <div id="collapse27" class="panel-collapse collapse">
                            <div class="panel-body">Go to the 'My Account' page and edit your email.

                               </div>
                             </div>
                            </div>
                                     <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse28">My swapnpurti.in profile is only partially visible. Why?

</a>
                                 </h4>
                           </div>
                         <div id="collapse28" class="panel-collapse collapse">
                            <div class="panel-body">Whenever you create a new Profile or you modify certain information in your Profile, the Profile is screened by the Customer Relations team of swapnpurti.in. During the screening process, only your essential information is displayed. Once the screening process is completed (usually within 24 hours) your Profile will be completely visible to everybody.

                               </div>
                             </div>
                                   </div>     
                                <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse29">Will my Profile be searchable online on Google, Yahoo etc ?

</a>
                                 </h4>
                           </div>
                         <div id="collapse29" class="panel-collapse collapse">
                            <div class="panel-body">Under normal circumstances it won't be discoverable in search engines but if you have mentioned your name in your profile-about me section then there are chances of profile being discoverable in search engines via full name.
                               </div>
                             </div>
                            </div>
                                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse30">Can I hide my swapnpurti.in profile temporarily?

</a>
                                 </h4>
                           </div>
                         <div id="collapse30" class="panel-collapse collapse">
                            <div class="panel-body">Yes you can. To hide your Profile, Go to your profile page and then click on the Hide / Delete Profile link.

                               </div>
                             </div>
                            </div>
                                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse31">Can I selectively hide my Profile from only some Members?

</a>
                                 </h4>
                           </div>
                         <div id="collapse31" class="panel-collapse collapse">
                            <div class="panel-body">No. If you choose to hide your Profile, it will be hidden from all swapnpurti.in Members.
                               </div>
                             </div>
                            </div>
                                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse32">What is "Activity Factor"?

</a>
                                 </h4>
                           </div>
                         <div id="collapse32" class="panel-collapse collapse">
                            <div class="panel-body">Activity factor gives an indication of how responsive you are. Maintaining a healthy Activity Factor increases your chances of being contacted by other Members.

                               </div>
                             </div>
                            </div>
                                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse33">Can I add my hobbies and Interests to my Profile?

</a>
                                 </h4>
                           </div>
                         <div id="collapse33" class="panel-collapse collapse">
                            <div class="panel-body">Yes, you can. Go to your profile to add your Hobbies & Interests now.
If your specific hobby or Interest is not included, please write to us and we will try to add it to the list.

                               </div>
                             </div>
                            </div>
                                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse34">Is it safe to add my horoscope along with the Profile?

</a>
                                 </h4>
                           </div>
                         <div id="collapse34" class="panel-collapse collapse">
                            <div class="panel-body">Yes, you have complete control over your privacy.
You can choose who you display your horoscope to by either choosing to show it to all Members or to only Members you Accept or Express Interest in.


                               </div>
                             </div>
                            </div>
                                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse35">Is it necessary to add a photo to my Profile? How can I add photos?

</a>
                                 </h4>
                           </div>
                         <div id="collapse35" class="panel-collapse collapse">
                            <div class="panel-body">Our statistics show that adding a photo to your Profile increases the number of times your Profile is viewed, by upto 7 times. You are also likely to receive 10 times as many responses if you add a Profile photo. You can add upto 20 photos to your swapnpurti.in Profile.
                               </div>
                             </div>
                            </div>
                                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion2" href="#collapse36"> I am now happily married to another Member of swapnpurti.in. Can I share the wonderful news with other Members? How do I go about doing this?

</a>
                                 </h4>
                           </div>
                         <div id="collapse36" class="panel-collapse collapse">
                            <div class="panel-body">We are thrilled that you found your life partner on swapnpurti.in. We would be more than happy to share this wonderful news with other swapnpurti.in Members, on your behalf. Your details will be posted in the Success Stories section of swapnpurti.in.

                               </div>
                             </div>
                            </div>
                            
                     </div>
                </div>

                <!-- Photographs Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion3">
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion3" href="#collapse37">Why should I add my photograph to my swapnpurti.in Profile?
</a>
                                 </h4>
                           </div>
                         <div id="collapse37" class="panel-collapse collapse">
                            <div class="panel-body">Our statistics show that adding a photo to your Profile increases the number of times your Profile is viewed, by upto 7 times. You are also likely to receive 10 times as many responses if you add a Profile photo. You can add upto 20 photos to your swapnpurti.in Profile.

                               </div>
                             </div>
                            </div>
                           <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion3" href="#collapse38">Is it safe to add my photos along with the Profile?
</a>
                                 </h4>
                           </div>
                         <div id="collapse38" class="panel-collapse collapse">
                            <div class="panel-body">Yes, it is absolutely safe to add Photos to your Profile. swapnpurti.in ensures that all photographs are watermarked so as to prevent your photos from being tampered with.


                               </div>
                             </div>
                            </div>
                                    <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion3" href="#collapse39">While uploading my photograph, I saw an error message that the image must be in jpg, gif, bmp, tiff or png format, what does this mean?
</a>
                                 </h4>
                           </div>
                         <div id="collapse39" class="panel-collapse collapse">
                            <div class="panel-body">Jpg, gif, bmp, tiff and png are the most popular digital image formats on the internet. swapnpurti.in accepts only these image formats for Profile photos.
                               </div>
                             </div>
                            </div>
                                     <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion3" href="#collapse40">How do I remove my Photo from my Profile?
</a>
                                 </h4>
                           </div>
                         <div id="collapse40" class="panel-collapse collapse">
                            <div class="panel-body">To remove your photo from your Profile, go to your My Photos page and use the delete function on the photo that you want to remove.


                               </div>
                             </div>
                            </div>
                                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion3" href="#collapse41">Why are my uploaded photos not appearing on my Profile?
</a>
                                 </h4>
                           </div>
                         <div id="collapse41" class="panel-collapse collapse">
                            <div class="panel-body">swapnpurti.in screens all photographs uploaded by Members to ensure that these photos are genuine and do not violate socially accepted norms. It takes us up to 24 hours to screen your photos, during which period your photos will not be visible. We will notify you via email once your photo passes the screening process and becomes visible on swapnpurti.in.

                               </div>
                             </div>
                            </div>
                              <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion3" href="#collapse42">What privacy options are available for photos?

</a>
                                 </h4>
                           </div>
                         <div id="collapse42" class="panel-collapse collapse">
                            <div class="panel-body">Privacy options of 'Password Protection' and 'Photo Visible to Contacted and Accepted Members' are available on swapnpurti.in.


                               </div>
                             </div>
                            </div>

                          </div>
                </div>



                <!-- Searching and Matching Profiles Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion4">
                              <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion4" href="#collapse43">How can I search for Profiles on swapnpurti.in? What are the search options available?
                                     </a>
                                 </h4>
                           </div>
                         <div id="collapse43" class="panel-collapse collapse">
                            <div class="panel-body">To search for Profiles on swapnpurti.in, you can use any of the following options: 
Basic Search allows you to search for Profiles as per basic criteria like age, height, marital status, religion, location, etc.
                                <ul>
                                    <li>The Advanced Search option gives you more detailed search options. The additional search options include education, profession, skin tone, manglik status, etc.</li>
                                     <li>The Who is Online option lets you search for Profiles who are currently online on swapnpurti.in.</li>
                                     <li>The Special Cases option allows you to search for physically/mentally challenged Members.</li>
                                     <li>The Saved Search option allows you to save upto five searches with different criteria. You can run a Saved Search at a later time to get a list of Members who match the criteria specified.</li>
                                     <li>The ‘Refine Search’ option appears on the left of your page after you have performed a search. The Refine Search feature allows you to drill down and filter your results based on photo availability, marital status, mother tongue, religion, country, state, city, education, profession and more.</li>
                                </ul>                                
Additionally, you can also use Profile ID search to locate particular Members on swapnpurti.in.
                               </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion4" href="#collapse44">In what order are my search results listed?
</a>
                                 </h4>
                           </div>
                         <div id="collapse44" class="panel-collapse collapse">
                            <div class="panel-body">Search results are shown by default using a custom algorithm developed by swapnpurti.in. This is used to maximise responses to your Profile. You can also sort the results by ‘Newest First’ and ‘Last Logged in First’.
                               </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion4" href="#collapse45">In the search results I can see some small icons next to some of the Profiles. What do those icons mean?
</a>
                                 </h4>
                           </div>
                         <div id="collapse45" class="panel-collapse collapse">
                            <div class="panel-body">swapnpurti.in uses different icons to denote the status of Profile information, e.g. whether Phone number is verified or not, whether horoscope is added or not, etc.

                               </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion4" href="#collapse46">What is the Matches feature? How does it work?
</a>
                                 </h4>
                           </div>
                         <div id="collapse46" class="panel-collapse collapse">
                            <div class="panel-body">Based on your Profile and Partner Preferences, swapnpurti.in shows you a list of Profiles under your Matches list.
                                <ul>
<li>Preferred Matches: These are Members who exactly match your Partner Preferences</li>
<li>Broader Matches: These are Members who match some of your Partner Preferences and are slightly outside some of your other Preferences.</li>
<li>Reverse Matches: These Members have set Partner Preferences that match your Profile information.</li>
<li>2-way Matches: Both of you match each others Partner Preferences.</li>
                                </ul>
                               </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion4" href="#collapse47">Can I shortlist Profiles that I like on swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse47" class="panel-collapse collapse">
                            <div class="panel-body">If you like a Member’s Profile, we recommend that you contact the Member immediately by Expressing Interest. In case you want to decide later, you can add these Members to a ‘Shortlist’. You can revisit these Profiles by visiting the Shortlists pageand decide to Express Interest later.
You can create upto 10 Shortlists. You can also add the same Profile to multiple Shortlists that you have created.

                               </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion4" href="#collapse48">Can I get a list of Members who have visited my Profile?
</a>
                                 </h4>
                           </div>
                         <div id="collapse48" class="panel-collapse collapse">
                            <div class="panel-body">Yes. Login your profile to see a list of Members who have recently viewed your Profile.

                               </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion4" href="#collapse49">What does the Ignore feature do? How is this useful?
</a>
                                 </h4>
                           </div>
                         <div id="collapse49" class="panel-collapse collapse">
                            <div class="panel-body">While searching you may come across Profiles that you may not want to consider in your Partner Search. You can Ignore such Profiles we will ensure that these Profiles will not shown again to you on swapnpurti.in.
By Ignoring irrelevant Profiles, you will be improving our algorithm that shows you Matches / Search Results. If you change your mind, you can access these Profiles from the Ignored Members list and Express Interest in them.
                               </div>
                             </div>
                            </div>
                          </div>
                </div>


                  <!-- Contacting & responding to Members on swapnpurti.in Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion5">

                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse50">How can I contact other Members on swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse50" class="panel-collapse collapse">
                            <div class="panel-body">Contacting Members on swapnpurti.in is FREE. You can contact Members that you like by Expressing Interest in their Profiles. These Members will receive an Interest from you, in their swapnpurti.in Inbox and will additionally receive a notification as well. These Members can choose to respond to your Interest by Accepting or Declining it.
                               </div>
                             </div>
                            </div>


                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse51">What additional benefits do I get as a Premium Member?

</a>
                                 </h4>
                           </div>
                         <div id="collapse51" class="panel-collapse collapse">
                            <div class="panel-body">As a Premium Member on swapnpurti.in you can send a “Premium Interest”, i.e. along with your Interest, you can post your Profile on the Member’s Wall and send an Email with your Profile to the Member.
Additionally you can also initiate Chats via Instant Messenger in order to get faster responses or grab more attention by sending an SMS directly to the Member's mobile phone.
 </div>
                             </div>
                            </div>

                             
                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse52">What does the Ignore feature do? How is this useful?
</a>
                                 </h4>
                           </div>
                         <div id="collapse52" class="panel-collapse collapse">
                            <div class="panel-body">While searching you may come across Profiles that you may not want to consider in your Partner Search. You can Ignore such Profiles we will ensure that these Profiles will not shown again to you on swapnpurti.in.
By Ignoring irrelevant Profiles, you will be improving our algorithm that shows you Matches / Search Results. If you change your mind, you can access these Profiles from the Ignored Members list and Express Interest in them.
                               </div>
                             </div>
                            </div>

                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse53">What is the meaning of Accepting, Declining or Canceling Interest with a Member on swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse53" class="panel-collapse collapse">
                            <div class="panel-body">Members who Express Interest in you, will appear in your Inbox. We recommend that your respond to these Interests by Accepting or Declining them. Accepting an Interest indicates that you agree to communicate with the Member. Click here to access your Accepted Members list. Declining an Interest indicates that you are not interested in the Member and do not wish to communicate any further.
While we recommend that you make it a point to respond to all Interests in your Inbox, you can also remove an Interest from your Inbox by Deleting it. In this case, the Member who sent you the Interest will not be notified.
In some cases, you may have second thoughts after Expressing Interest in a Member. In such cases, you can Cancel your Interest and stop all further communication.
You can find all Declined, Cancelled and Deleted Interests in your Deleted folder.
                               </div>
                             </div>
                            </div>

                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse54">Can I Decline a Member after having Accepted him/her?
</a>
                                 </h4>
                           </div>
                         <div id="collapse54" class="panel-collapse collapse">
                            <div class="panel-body">Yes, you can Decline a Member that you have Accepted.

                               </div>
                             </div>
                            </div>

                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse55">Can I Accept a Member after Declining him/her?
</a>
                                 </h4>
                           </div>
                         <div id="collapse55" class="panel-collapse collapse">
                            <div class="panel-body">Yes, you can Accept a Member after Declining.
 </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse56">If I Express Interest in a Member, and the Member Accepts me, will I be able to Cancel the Interest later?
</a>
                                 </h4>
                           </div>
                         <div id="collapse56" class="panel-collapse collapse">
                            <div class="panel-body">Yes, you can Cancel your Interest in this Member.</div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse57">What is the 'My Filters' feature?</a>
                                 </h4>
                           </div>
                         <div id="collapse57" class="panel-collapse collapse">
                            <div class="panel-body">‘My Filters’ helps you to filter out Members on the basis of multiple criteria like Age, Marital Status, Height, Manglik/Kuja Dosham, Religious Background, Country of Residence, etc. Interests from Members who do NOT meet your Filter criteria will appear in the ‘Filtered out’ folder in your Inbox.
Note: Setting Filters that are too tight may considerably reduce the number of Interests that you receive in your Inbox. We recommend that you use this feature ONLY if you are receiving Interests by too many Members who don't meet your requirements.</div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse58">Can I Express Interest in Members who have Filtered me out?
</a>
                                 </h4>
                           </div>
                         <div id="collapse58" class="panel-collapse collapse">
                            <div class="panel-body">Yes, even if you do not meet the Filter criteria of the Member, you still have a chance to Express Interest in the Member’s Profile. This Interest will appear in the Member’s Filtered out folder and may result in a delayed response.
 </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse59">How does the "Request Photo" feature work?
</a>
                                 </h4>
                           </div>
                         <div id="collapse59" class="panel-collapse collapse">
                            <div class="panel-body">As the name suggests, the Request Photo feature allows you to request Members to add photos to their Profile. To use this feature:
                                <ul>
                                    <li> Login to swapnpurti.in </li>
                                    <li>Ensure that your own photo is added to your Profile</li>
                                    <li>If you see a Profile that doesn’t have a photograph, you can request a photo by clicking on the ‘Request Photo’ button</li>
                                    <li>We will convey your request to the Member who will automatically be added to your  Sent Requests folder</li>
                                    <li>We will send you an email notification if the Member uploads his/her photo</li>
                                    <li>Similarly, you can check the Requests tab in your Inbox and respond to Photo Requests that you receive</li>                       
                                </ul>
 </div>
                             </div>
                            </div>
                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse60">How does the "Request Contact Details" feature work?

</a>
                                 </h4>
                           </div>
                         <div id="collapse60" class="panel-collapse collapse">
                            <div class="panel-body">The "Request Contact Details" feature allows you to request contact details of Members who have either not entered contact details or have selected not to display their contact details to Premium Members. To use this feature:
                                <ul>
                                    <li> Login to swapnpurti.in </li>
                                    <li>If a Member has not Verified his / her phone number Click on the "Request Phone Number" link on a Member's Profile page.</li>
                                    <li>This Request will appear in the other Member’s Inbox and he/she can choose to approve your Request by Verifying his / her contact details.</li>
                                    <li>If the Member approves your Request, you will receive an email confirming that the Member has Verified his/her contact details.</li>
                                    <li>Similarly, if the Member requests your Contact Details, this Request will appear in your Inbox under the ‘Requests’ tab</li>                                                     
                                </ul>
 </div>
                             </div>
                            </div>
                                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion5" href="#collapse61">I saw a Profile that I like on swapnpurti.in. Can the Customer Support Team of swapnpurti.in help me contact this Member of swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse61" class="panel-collapse collapse">
                            <div class="panel-body">While the Customer Relations team of swapnpurti.in strives to facilitate matrimony between its Members, the team is not authorised to contact Members on your behalf. You may want to consider the Select AnuvaaMatrimony service where a team of experts manage your Profile on your behalf.

 </div>
                             </div>
                            </div>   
                          </div>
                </div>


                  <!-- AnuvaaMatrimony Chat Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion6">
                          <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion6" href="#collapse62">Who can I see online on my AnuvaaMatrimony Chat list?
</a>
                                 </h4>
                           </div>
                         <div id="collapse62" class="panel-collapse collapse">
                            <div class="panel-body">On the AnuvaaMatrimony Chat list you can see Accepted Members, Shortlists and Matches who are online. Using AnuvaaMatrimony Chat is completely FREE.
 </div>
                             </div>
                            </div>   
                            <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion6" href="#collapse63">What additional benefits do I get as a Premium Member?
</a>
                                 </h4>
                           </div>
                         <div id="collapse63" class="panel-collapse collapse">
                            <div class="panel-body">As a Premium Member, you can initiate Chats and highlight your Profile in order to get faster responses.
 </div>
                             </div>
                            </div>   
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion6" href="#collapse64">Can I search for Members who are currently Online on swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse64" class="panel-collapse collapse">
                            <div class="panel-body">Yes, you can search for Online Members by using the Who is Online search.
 </div>
                             </div>
                            </div>   
                                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion6" href="#collapse65">If I am already chatting with someone and do not wish to be disturbed by getting more Chats what can I do?
</a>
                                 </h4>
                           </div>
                         <div id="collapse65" class="panel-collapse collapse">
                            <div class="panel-body">You can appear offline to all Members while continuing to chat with Members you prefer. You can do this by changing your Chat Status from “I am Online” to "Invisible".
 </div>
                             </div>
                            </div>   
                                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion6" href="#collapse66">I do not wish to receive Chat requests when I am browsing on swapnpurti.in what do I do?
</a>
                                 </h4>
                           </div>
                         <div id="collapse66" class="panel-collapse collapse">
                            <div class="panel-body">You can go offline from AnuvaaMatrimony Chat by changing your Chat status from "I am Online" to "Offline". Please note that this will decrease your chances of being contacted, as Members will not see you online on their AnuvaaMatrimony Chat list.
 </div>
                             </div>
                            </div>   
                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion6" href="#collapse67">How can I stop chatting with a particular Member?
</a>
                                 </h4>
                           </div>
                         <div id="collapse67" class="panel-collapse collapse">
                            <div class="panel-body">You can "Ignore" or "Decline" a particular Member if you do not wish to receive any Chats from them. These Members will also not be able to see you online on AnuvaaMatrimony Chat.
 </div>
                             </div>
                            </div>   


                          </div>
                </div>

                
                  <!-- Memberships on swapnpurti.in Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion7">
                        
                                    
                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion7" href="#collapse68">What are the benefits of a FREE Membership?
</a>
                                 </h4>
                           </div>
                         <div id="collapse68" class="panel-collapse collapse">
                            <div class="panel-body">Registration on swapnpurti.in is FREE !!. For absolutely no cost, you can register and create your Profile. Some of the benefits you get as a free Member are:
                        <ul>
                            <li>Create your Profile on swapnpurti.in</li>
                             <li>Add upto 20 photos to your Profile (privacy options available)</li>
                             <li>Add your contact details (privacy options available)</li> 
                             <li>Add additional Profile information like Family details, Horoscope details, Hobbies/Interests, etc</li>
                             <li>Set your Partner Preferences to get the right Matches</li>
                             <li>Receive Daily Matches on your Email id</li>
                             <li>Search for Profiles using upto 26 parameters like Age, Height, Religion, etc</li>
                             <li>Browse Matches as per your Partner Preferences</li>
                             <li>Contact / Express Interest in Members you like</li>
                             <li>Get Notified and Respond (Accept/Decline) to Members who contact you</li>
                             <li>Shortlist the Profiles that you like and view them later</li>
                             <li>Ignore Profiles that you don't like and hide them from your Search results/Matches</li>
                        </ul>

                                </div>
                             </div>
                            </div>   
                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion7" href="#collapse69">What is a Premium Membership?
</a>
                                 </h4>
                           </div>
                         <div id="collapse69" class="panel-collapse collapse">
                            <div class="panel-body">A paid Membership is called a Premium Membership on swapnpurti.in. Premium Members enjoy additional features by which they can promote their Profile on swapnpurti.in to other Members.
 </div>
                             </div>
                            </div>   
                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion7" href="#collapse70">What are the primary benefits of becoming a Premium Member?
</a>
                                 </h4>
                           </div>
                         <div id="collapse70" class="panel-collapse collapse">
                            <div class="panel-body">As a Premium Member, you can accelerate your Partner Search because of the following benefits:-
                                <ul>
                                    <li>Connect directly with Profiles you like over Phone, Email or SMS.</li>
                                    <li>Initiate Unlimited Chats and Emails</li>
                                    <li>Get faster Responses with top placement on AnuvaaMatrimony Inbox of Profiles you like</li>
                                    <li>Stand out in Search Listings via Bold Listing and Spotlight</li>
                                </ul>
                                Becoming a Premium Member is the right step towards accelerating your Partner Search. Our data shows that finding a partner is 12 times more likely if you upgrade to a Premium Membership

 </div>
                             </div>
                            </div>   
                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion7" href="#collapse71">What are the different Membership Plans on swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse71" class="panel-collapse collapse">
                            <div class="panel-body">
                                <ul>
                                    <li><b>Premium Plan: </b>This is subcategorized into Gold (3 months), Diamond (6 months), Platinum (12 months)</li>
                                    <li><b>Premium Plus Plan:</b>  This is subcategorized into Gold Plus (3 months) , Diamond Plus (6 months), Platinum Plus (12 months)</li>
                                    <li><b>Personalised Plans:</b> These are subcategorized into Select Membership (3 months and 6 months) and VIP Membership (3 months and 6 months)</li>
                                </ul>
                                Both Premium and Premium Plus Members enjoy the benefits as described above. Premium Plus Members can additionally promote their Profile via 'Bold Listing' and 'Spotlight'. A Dedicated Advisor handpicks Matches for you and initiates conversations on your behalf for all Personalised Plans.

 </div>
                             </div>
                            </div>   
                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion7" href="#collapse72">What is Bold Listing?
</a>
                                 </h4>
                           </div>
                         <div id="collapse72" class="panel-collapse collapse">
                            <div class="panel-body">Bold Listing makes your Profile stand out in a Search result page amongst thousands of other Profiles and increases your chances of being contacted.
Your Profile will be made bold whenever it appears in:
                                <ul>
                                    <li>Search results.</li>
                                    <li>Preferred & Broader Matches</li>
                                    <li>Reverse Matches</li>
                                    <li>2-way Matches</li>
                                </ul>
 </div>
                             </div>
                            </div>   
                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion7" href="#collapse73">What is swapnpurti.in Spotlight?
</a>
                                 </h4>
                           </div>
                         <div id="collapse73" class="panel-collapse collapse">
                            <div class="panel-body">The swapnpurti.in Spotlight features Profiles right on top of relevant Search results. Being featured here increases your chances of being contacted by 10 times!
 </div>
                             </div>
                            </div>   
                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion7" href="#collapse74">Can I avail discounts while purchasing Premium Memberships?
</a>
                                 </h4>
                           </div>
                         <div id="collapse74" class="panel-collapse collapse">
                            <div class="panel-body">swapnpurti.in offers discounts to new Premium Membership registrations from time to time as part of its ongoing promotion plan. If you have received a promotional code, you can enter it while placing your order and receive your discount. If not, we may not have any promotions running currently. </div>
                             </div>
                            </div>   
                                       <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion7" href="#collapse75">What are the additional costs involved to Upgrade to a Premium Membership?
</a>
                                 </h4>
                           </div>
                         <div id="collapse75" class="panel-collapse collapse">
                            <div class="panel-body">Prices Listed on swapnpurti.in are inclusive of all taxes viz. Service Tax. There are no additional costs.
 </div>
                             </div> </div>
                               <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion7" href="#collapse76">How can I renew / upgrade my Membership?
</a>
                                 </h4>
                           </div>
                         <div id="collapse76" class="panel-collapse collapse">
                            <div class="panel-body">Upgrading to a Premium Membership is easy. Click here to view our Membership options and select one to Upgrade!
</div>
                             </div>
                            </div>   
                                                  
                         
                             </div>
                </div>


                  <!-- Payment Options Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion8">
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse77">How can I purchase a swapnpurti.in Premium Membership?
</a>
                                 </h4>
                           </div>
                         <div id="collapse77" class="panel-collapse collapse">
                            <div class="panel-body">Select Upgrade option from your profile !</div>
                             </div>
                            </div> 
                                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse78">What are the different ways of payment accepted by swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse78" class="panel-collapse collapse">
                            <div class="panel-body">swapnpurti.in offers you wide-ranging easy payment options -
                           <br /><b>   Online Options:</b>
                                  <ul>
                                    <li>Credit cards. We accept all leading credit cards. You can use your credit card to make a payment online.    </li>
                                       <li>Net banking. You can pay us via the net banking service of leading Indian banks.  Citibank, ICICI Bank, HDFC Bank, AXIS Bank (formerly UTI Bank), IDBI Bank, Federal Bank, Bank of Punjab, Punjab National Bank, Bank of Rajasthan.</li>
                                      
                                </ul>
                                  <br /><b>  Other Easy Options</b>

                                <ul>
                                     <li>Free home collection of your cheque / draft. This service is currently available in 717 cities across India. </li>
                                       <li>swapnpurti.in Collection Centres. Pay cash / cheque at any swapnpurti.in Collection Centre and activate your order instantly. To locate your nearest centre in India, click here </li>
                                       <li>Free pickup of your cash / cheque / demand draft. This service is currently available in the 7 emirates across the United Arab Emirates. You can call Aramex Memo Express on 04-3671881 to arrange for a pickup. </li>
                                       <li>Cash payment at UAE Exchange. Walk into the nearest UAE Exchange branch in your city, and pay cash. To locate nearest center, click here </li>
                                </ul>
                                Depending on your convenience you can choose any one of the above payment options while placing an order.
</div>
                             </div>
                            </div>

                                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse79">Can I pay online using my credit card?
</a>
                                 </h4>
                           </div>
                         <div id="collapse79" class="panel-collapse collapse">
                            <div class="panel-body">Yes you can. We accept all leading credit cards.
</div>
                             </div>
                            </div>

                                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse80">Is online Credit Card payment on swapnpurti.in secure?
</a>
                                 </h4>
                           </div>
                         <div id="collapse80" class="panel-collapse collapse">
                            <div class="panel-body">Yes, 100% Secure! Your credit card information is entered on a Secure Server using SSL Technology and 128 Bit Encryption which is one of the highest level of security provided by websites. The information is transmitted in an encrypted fashion to our payment gateway and your card is charged online. Finally, to provide the highest level of security, we do not store your credit card information on our online server at any time.  </div>
                             </div>
                            </div>
                                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse81">What types of credit cards are accepted for payment?
</a>
                                 </h4>
                           </div>
                         <div id="collapse81" class="panel-collapse collapse">
                            <div class="panel-body">We accept all Master and Visa credit cards. 
</div>
                             </div>
                            </div>
                                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse82">Can I pay using a Debit Card?
</a>
                                 </h4>
                           </div>
                         <div id="collapse82" class="panel-collapse collapse">
                            <div class="panel-body">Yes, you can pay using your Visa Debit Card. We would like to caution you that some banks that issue Debit Cards do not allow online Debit Card payments. So please check with your bank.

</div>
                             </div>
                            </div>

                                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse83">I placed an order and was given an Order ID afterwards. What is an Order ID?
</a>
                                 </h4>
                           </div>
                         <div id="collapse83" class="panel-collapse collapse">
                            <div class="panel-body">The Order ID uniquely identifies the order placed by you. After you are given the Order ID, be sure to make a note of it and save it for later reference. When you correspond with the Customer Relations team at swapnpurti.in, your Order ID will help the team to quickly track your order details.  
</div>
                             </div>
                            </div>
                                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse84">How long does it take to activate my Membership after I place an order?
</a>
                                 </h4>
                           </div>
                         <div id="collapse84" class="panel-collapse collapse">
                            <div class="panel-body">If you pay for the order using a credit card, then the account is activated within 12 hours. If you pay via cheque, demand draft or a bank draft, the account is activated within 5 working days.
</div>
                             </div>
                            </div>

                                        <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse85">I have already made a payment, but my Premium Membership is not yet active. Why?
</a>
                                 </h4>
                           </div>
                         <div id="collapse85" class="panel-collapse collapse">
                            <div class="panel-body">If you have sent us your payment via demand draft it is possible that we have not received the payment yet. Your Premium Membership will be activated only once we receive the payment. We will notify you via email, once we receive the payment and activate your Premium Membership.
Optionally, if you have made an online payment using your credit card, and your account is still not active, it is possible that we might require some more information from you. Also, sometimes it takes upto 12 hours for the payment notification to reach us. We will notify you via email, once we receive the payment and activate your Premium Membership. 
</div>
                             </div>
                            </div>
                                  <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion8" href="#collapse86">What is the swapnpurti.in’s refund policy?
</a>
                                 </h4>
                           </div>
                         <div id="collapse86" class="panel-collapse collapse">
                            <div class="panel-body">Since swapnpurti.in allows its Members to communicate with other Members before they pay, we generally do not refund Membership fees. This policy, while providing value for money for swapnpurti.in Members, also ensures that the company is protected. Any exceptions to this policy will be made at the sole discretion of the swapnpurti.in management.  </div>
                             </div>
                            </div>
                               
                          </div>
                </div>


                 <!-- swapnpurti.in Alerts Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion9">
                            <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion9" href="#collapse87">What are swapnpurti.in Alerts? Why should I subscribe to them?
</a>
                                 </h4>
                           </div>
                         <div id="collapse87" class="panel-collapse collapse">
                            <div class="panel-body">swapnpurti.in Alerts help you get instant updates of the important activity related to your Profile. This is an effective way of being notified whenever you receive new Matches / Interests / Responses on swapnpurti.in and helps you find your life partner faster.
To know more about all the available alerts that you can subscribe to and manage your subscription options, visit your Email / SMS Alerts settings.
  </div>
                             </div>
                            </div>

                   <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion9" href="#collapse88">What are swapnpurti.in Alerts? Why should I subscribe to them?
</a>
                                 </h4>
                           </div>
                         <div id="collapse88" class="panel-collapse collapse">
                            <div class="panel-body">Subscribing to swapnpurti.in Newsletters helps you fully utilize our services to
                                <ul>
                                    <li>find your ideal life-partner quickly and easily;</li>
                                     <li>stay updated on trends and developments in wedding-related issues; and</li>
                                     <li>enjoy special offers and invitations.</li>
                                </ul>
                                To know more about all the available alerts that you can subscribe to and manage your subscription options, visit your Email / SMS Alerts settings.

  </div>
                             </div>
                            </div>

                                <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion9" href="#collapse89">I have subscribed to swapnpurti.in Alerts. Why can't I find any email Alerts in my Gmail Inbox?
</a>
                                 </h4>
                           </div>
                         <div id="collapse89" class="panel-collapse collapse">
                            <div class="panel-body">Gmail has recently added 3 tabs to their Inbox - Primary, Social and Promotions. By default, Gmail has classified swapnpurti.in emails to appear under the 'Social' tab. As a result, you may be missing important updates from swapnpurti.in.
Follow these quick steps to ensure that you never miss any of our emails:

                                <ul>
                                    <li><b>Step 1:</b> Login into Gmail, click on the Social tab and find an email from swapnpurti.in.</li>
                                     <li><b>Step 2:</b> Drag this email into your Primary tab.</li>
                                     <li><b>Step 3:</b> Click 'Yes' on the confirmation message to get all future emails in your Primary tab.</li>
                                </ul>
                                View a quick demo below:
                                        Go to Gmail now

  </div>
                             </div>
                            </div>



                          </div>
                </div>
                 <!-- Technical issues Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion10">

                                 <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion10" href="#collapse90">I am facing an error while using swapnpurti.in. What should I do?
</a>
                                 </h4>
                           </div>
                         <div id="collapse90" class="panel-collapse collapse">
                            <div class="panel-body">We are sorry that you are facing an error while trying to use our services. We urge you to report this error to our Customer Relations team with the following details:
                                <ul>
                                    <li>The URL, that leads to the error</li>
                                     <li>The error message</li>
                                     <li>The date, time and location of access when you encounter the error.</li>
                                </ul>                          
  </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion10" href="#collapse91">What are browser cookies? Why are they important for using swapnpurti.in?
</a>
                                 </h4>
                           </div>
                         <div id="collapse91" class="panel-collapse collapse">
                            <div class="panel-body">Weswapnpurti.in uses cookies to deliver the various services and to keep track of your personal preference. A cookie is a small text file that can be entered into the memory of your browser to help a web site recognize repeat users, facilitate the user's ongoing access to and use of the site and make content improvements and targeted advertising.
Please note that the use of cookies is a necessary part of the swapnpurti.in technology and are necessary if you wish to access swapnpurti.in. Disabling the cookie feature on your browser or deleting cookie files from your computer will render you unable to access certain features on swapnpurti.in and participate in its services. Cookies may also be necessary to provide the user with certain features such as customized delivery of information.
swapnpurti.in uses cookies to provide its core matrimonial service, to deliver content specific to your Interests, to save your password so you don't have to re-enter it each time you visit different pages on our site, and for other purposes. We do not and will not use cookies to collect private information from any user. Please note that cookies are used only to recollect information sent to your computer from swapnpurti.in. We CANNOT access any information on your computer that is not sent by swapnpurti.in.
           
  </div>
                             </div>
                            </div>
                             <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion10" href="#collapse92">Why don't I see any new content on swapnpurti.in? I see the same content as yesterday.</a>
                                 </h4>
                           </div>
                         <div id="collapse92" class="panel-collapse collapse">
                            <div class="panel-body">We are sorry that you are facing an error while trying to use our services. We urge you to report this error to our Customer Relations team with the following details:
                               The reason for this could be related to your Internet Browser. Your browser seems to be displaying old content and is not refreshing the content. This is called caching. To refresh your page successfully, access your content settings and clear your cache.
  </div>
                             </div>
                            </div>

                          </div>
                </div>
                 <!-- Privacy and Security Tips Section -->
                <div class="bhoechie-tab-content">
                         <div class="panel-group" id="accordion11"> 
                              <div class="panel panel-default">
                                   <div class="text-justify faqpad">
                                swapnpurti.in aims to provide you with a safe & secure environment in which you search and find your life partner.
                                       <br />
                                  <ul>
                                      <li>Our Customer Relations team ensures that every profile put up at swapnpurti.in is screened for irrelevant and/or inappropriate content.</li>
                                      <li>We also have strict abuse-prevention and reporting systems for those that do get through our screening systems.</li>                                     
                                  </ul>
                                       <br />
                                  However, in ensuring your safety & privacy, we're limited to actions that are within our control. Therefore, it is necessary for you to exercise some simple precautions for your privacy & for a safe and secure experience.
Here are some simple guidelines YOU can follow to protect your privacy.
                                </div>
                                  </div>


                                               <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion11" href="#collapse93">Guard your anonymity
</a>
                                 </h4>
                           </div>
                         <div id="collapse93" class="panel-collapse collapse">
                            <div class="panel-body">Our system of anonymous contacting (expressing interest, accepting/declining), and private messaging (Communicate section) is to ensure that your identity is protected until YOU decide to reveal it.
                             <br />  <b>Do</b> 
                                <ul>
                                    <li>Remember that you are in control of your online experience at all times. You can remain completely anonymous until YOU choose not to. </li>
                                   
                                </ul>
                                   <b>Don't</b> 
                                  <ul>
                                    <li>Don't include your personal contact information like name, email address, home address, telephone numbers, place of work or any other identifying information in your initial messages. </li>
                                      <li>Don't send contact information until your instincts tell you that this is someone you can trust. It's okay to take your time. </li>
                                    
                                </ul>
 </div>
                             </div>
                            </div>

                                                     
                                               <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion11" href="#collapse94">Start slow - Use emails initially
</a>
                                 </h4>
                           </div>
                         <div id="collapse94" class="panel-collapse collapse">
                            <div class="panel-body">Set up a separate email account for communicating. Trust your instincts and start by sharing only your email address and communicating solely via email.
                            <br />   <b>Do</b> 
                                <ul>
                                    <li>Look for odd behavior or inconsistencies. Serious people will respect your space and allow you to take your time. </li>
                                   <li>Ask a friend to read the emails you receive - an unbiased observer can spot warning signs you missed. </li>
                                    <li>Stop communicating with anyone who pressures you for personal information or attempts in any way to trick you into revealing it. </li>
                                </ul>
                                   <b>Don't</b> 
                                  <ul>
                                    <li>Don't use signature lines in your emails that include your phone numbers and addresses. </li>
                                      <li>Don't use your regular or official email id for communicating with a person you don't know well. </li>
                                    
                                </ul>
 </div>
                             </div>
                            </div>
                             
                                               <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion11" href="#collapse95">Request for a photo</a>
                                 </h4>
                           </div>
                         <div id="collapse95" class="panel-collapse collapse">
                            <div class="panel-body">A photo will give you a good idea of the person's appearance, which may prove helpful in achieving a gut feeling.
                              <br /> <b>Do</b> 
                                <ul>
                                    <li>You can use the Photo Request option on swapnpurti.in. Since swapnpurti.in offers free scanning & upload services to its members, there's no reason someone shouldn't be able to provide you a photo. </li>
                                   <li>In fact, it's best to view several images of someone in various settings: casual, formal, indoor and outdoors. If all you hear are excuses about why you can't see a photo, consider that he or she has something to hide.</li>
                                </ul>
                                   </div>
                             </div>
                            </div>
                                              
                                               <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion11" href="#collapse96">Chat on the phone
</a>
                                 </h4>
                           </div>
                         <div id="collapse96" class="panel-collapse collapse">
                            <div class="panel-body">A phone call can reveal much about a person's communication and social skills. Consider your security and do not reveal your personal phone number to a stranger.
                            <br />   <b>Do</b> 
                                <ul>
                                    <li>Use a pre paid mobile phone number or use local telephone blocking techniques to prevent your phone number from appearing in Caller ID. Only furnish your phone number when you feel completely comfortable and have some background information on the other person. </li>
                                   
                                
                                      <li>If someone gives you a phone number with a strange area code, check it out to make sure it's not a charge number before you make the call. </li>
                                    
                                </ul>
 </div>
                             </div>
                            </div>
                                              
                                               <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion11" href="#collapse97">Meet when YOU are ready</a>
                                 </h4>
                           </div>
                         <div id="collapse97" class="panel-collapse collapse">
                            <div class="panel-body">The beauty of meeting online is that you can collect information gradually, later choosing whether to pursue the relationship in the offline world. You never are obligated to meet anyone. Go at your own pace!
                             <br />  <b>Do</b> 
                                <ul>
                                    <li> Remember that you are in control when it comes to taking an online relationship offline.</li>
                                   
                                   <li>Even if you decide to arrange a meeting, you always have the right to change your mind. It's possible that your decision to keep the relationship at the anonymous level is based on a hunch that you can't logically explain. Trust yourself. Go with your instincts. </li>
                                    
                                </ul>
 </div>
                             </div>
                            </div>
                             
                                               <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion11" href="#collapse98"> Meet in a safe place
</a>
                                 </h4>
                           </div>
                         <div id="collapse98" class="panel-collapse collapse">
                            <div class="panel-body">When you choose to meet offline it is a good idea to try and include either or both of your families. But if you trust the person enough to meet alone always tell a friend or your family where you are going and when you will return.
                             <br />  <b>Do</b> 
                                <ul>
                                    <li> When you decide to meet face to face with someone for the first time, choose a public place (such as a restaurant / cafe) at a time when many people are around and ensure your own transportation to and fro.</li>                                  
                                    <li>For the first meeting it is always good not to meet the other person alone. Take a friend or relative along and ask him/her to do the same. </li>
                                      <li>In case you do decide to meet him/her alone leave the name, address and telephone number of the person you are going to meet with your friend or family member. Take a cellular phone along with you. </li>
                                    
                                </ul>
                                 <b>Don't</b> 
                                  <ul>
                                    <li>Never arrange for your prospective match to pick you up or drop you at home. </li>
                                      <li>Do not go to a secluded place or a movie alone at the first meeting. </li>
                                    
                                </ul>
 </div>
                             </div>
                            </div>
                                               <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion11" href="#collapse99"> Watch for warning signs
</a>
                                 </h4>
                           </div>
                         <div id="collapse99" class="panel-collapse collapse">
                            <div class="panel-body">Watching for warning signs and acting upon it is the surest way to avoid an uncomfortable situation.
                              <br /> <b>Do</b> 
                                <ul>
                                    <li> Ask a lot of questions and watch for inconsistencies. This will help you detect liars & cons, and it will help you find out if you're compatible.</li>
                                   <li>Pay attention to displays of anger, intense frustration or attempts to pressure or control you. Acting in a resentful manner, making demeaning or disrespectful comments, or any physically inappropriate behavior are all warning signs.</li>
                               <li>Involve your family or your close friends in your search for a life partner and do not take a decision unilaterally.</li>
                                     </ul>
                                   <b>Don't</b> 
                                    Don't ignore the following behavior specially if it is without an acceptable explanation:
                                  <ul>
                                    <li> Provides inconsistent information about age, interests, appearance, marital status, profession, employment, etc.</li>
                                      <li>Fails to provide direct answers to direct questions </li>
                                      <li>Appears significantly different in person from his or her online persona</li>
                                      <li>Never introduces you to friends, professional associates or family members</li>
                                    
                                </ul>
 </div>
                             </div>
                            </div>
                                <div class="panel panel-default">
                            <div class="panel-heading">
                                 <h4 class="panel-title">
                                 <a data-toggle="collapse" data-parent="#accordion11" href="#collapse100">Beware of money scams
</a>
                                 </h4>
                           </div>
                         <div id="collapse100" class="panel-collapse collapse">
                            <div class="panel-body">Watch out for money scams. There are just too many con artists and scam artists around the world, and they are everywhere.
                              <br /> <b>Do</b> 
                                <ul>
                                    <li>Be wary of those who try to ask money from you for whatever reason. But it would be safer to cut off the communication. Remember a genuine person will not ask you for money in any circumstance. If someone asks you for money, use common sense and never give in to such requests. </li>
                                   <li>In case someone asks you for money report the situation to us.</li>
                                </ul>
                                   <b>Don't</b> 
                                  <ul>
                                    <li>Take all the time you need to decide on a trustworthy person and pay careful attention along the way. Be responsible about romance, and don't fall for the oldest con tricks of people who shower love and affection at the first instance and disappear later. Don't become prematurely close to someone, even if that intimacy only occurs online. </li>
                                    
                                </ul>
 </div>
                             </div>
                            </div>
 <div class="panel panel-default">
                       <div class="text-justify faqpad">        
                           Using your own good judgment is your best bet because ultimately you are responsible for your personal experience. Trust your instincts and then move ahead with the right person!<br />
                           <br />
If you do have an unpleasant experience you can always report it to the authorities.<br />
                           <br />
swapnpurti.in to assist Mumbai Police / Statutory Investigation Agency<br />
swapnpurti.in will endeavour to provide all possible assistance to the Mumbai Police (Cyber Crime Investigation Cell) or any other statutory investigation agency to tackle fraudulent users of swapnpurti.in, on being specifically instructed by the said authorities to do so.<br />
                           <br />
To report fraud or misuse, write to us giving full details of your case.

     </div></div>
                             
                          </div>
                </div>

            </div>
        </div>
  </div>
</div>
</asp:Content>

