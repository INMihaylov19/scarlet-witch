import { useState } from "react";
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import axios from 'axios';
import './Create.css'

const Create = () => {
  const [name, setName] = useState('Name');
  const [address, setAddress] = useState('');
  const [email, setEmail] = useState('@gmail.com');
  const [phone, setPhone] = useState('');
  const [institute, setInstitute] = useState('Institute');
  const [degree, setDegree] = useState('');
  const [fieldOfStudy, setFieldOfStudy] = useState('');
  const [eduStartDate, setEduStartDate] = useState('');
  const [eduEndDate, setEduEndDate] = useState('');
  const [company, setCompany] = useState('Company');
  const [position, setPosition] = useState('');
  const [workStartDate, setWorkStartDate] = useState('');
  const [workEndDate, setWorkEndDate] = useState('');
  const [description, setDescription] = useState('');
  const [certName, setCertName] = useState('');
  const [organization, setOrganization] = useState('Organization');
  const [issueDate, setIssueDate] = useState('');
  const [expirationDate, setExpirationDate] = useState('');
  const [language1, setLanguage1] = useState(''); 
  const [level1, setLevel1] = useState(''); 
  const [language2, setLanguage2] = useState(''); 
  const [level2, setLevel2] = useState(''); 
  const [skill1, setSkill1] = useState(''); 
  const [skill2, setSkill2] = useState(''); 
  const [skill3, setSkill3] = useState(''); 
  const [headline, setHeadline] = useState('Here you can add a headline!'); 

  const createCertificate = async () => {
      const url = 'https://localhost:7119/api/Certificates';
      const data = {
        name: certName,
        organization: organization,
        issueDate: issueDate,
        expirationDate: expirationDate
      }

      axios.post(url, data);
  };
  
  const createSkill = async () => {
    const url = 'https://localhost:7119/api/Skills';
    const data = {
      name: skill1
    }
    axios.post(url, data);

    const data2 = {
      name: skill2
    }
    axios.post(url, data2);

    const data3 = {
      name: skill3
    }
    axios.post(url, data3);
  };

  const createEducation = async () => {
    const url = 'https://localhost:7119/api/Educations';
    const data = {
      institute: institute,
      degree: degree,
      fieldOfStudy: fieldOfStudy,
      startDate: eduStartDate,
      endDate: eduEndDate
    }

    axios.post(url, data);
  };



  const createWorkExperience = async () => {
    const url = 'https://localhost:7119/api/WorkExperiences';
    const data = {
      company: company,
      position: position,
      startDate: workStartDate,
      endDate: workEndDate,
      description: description
    }

    axios.post(url, data);
  };

  const createUser = async () => {
    const url = 'https://localhost:7119/api/PersonalInfoes';
    const data = {
      firstName: name,
      email: email
    }

    axios.post(url, data);
  };

  const createLanguage = async() => {
    const url = 'https://localhost:7119/api/Languages';
    const data = {
      name: language1,
      proficiency: level1
    }
    axios.post(url, data);
    const data2 = {
      name: language2,
      proficiency: level2
    }
    axios.post(url, data2);
  };

  const createPersonalInfo = async () => {
    const url = 'https://localhost:7119/api/PersonalInfoes';
    const data = {
      address: address,
      phone: phone
    }

    axios.post(url, data)
  };

  const buttonHandler = () => {
    createCertificate();
    createSkill();
    createEducation();
    createWorkExperience();
    createLanguage();
    //createUser();
    createPersonalInfo();
  }


  const [loader, setLoader] = useState(false);
  const handleDownloadPDF = () => {
    const capture = document.querySelector('.cv');
    setLoader(true);
    html2canvas(capture).then((canvas)=>{
      const imgData = canvas.toDataURL('img/png');
      const doc = new jsPDF('p', 'mm', 'a4');
      const componentWidth = doc.internal.pageSize.getWidth();
      const componentHeight = doc.internal.pageSize.getHeight();
      doc.addImage(imgData, 'PNG', 0, 0, componentWidth, componentHeight);
      setLoader(false);
      doc.save('cv.pdf');
    })

    buttonHandler();
  }

  return (
    <div className="create">
        <div className="input-wrapper">
          <h2>CV information:</h2>
          <form>
            <p className="form--headers">Personal info:</p>
            <label>Name:</label>
            <input 
              type="text" 
              required 
              value={name}
              onChange={(e) => setName(e.target.value)}
            />
            <label>Address:</label>
            <input 
              type="text" 
              required 
              value={address}
              onChange={(e) => setAddress(e.target.value)}
            />
            <label>Email:</label>
            <input 
              type="email" 
              required 
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <label>Phone:</label>
            <input 
              type="tel" 
              required 
              value={phone}
              onChange={(e) => setPhone(e.target.value)}
            />
            <p className="form--headers">Education:</p>
            <label>Institute:</label>
            <input 
              type="text" 
              required 
              value={institute}
              onChange={(e) => setInstitute(e.target.value)}
            />
            <label>Degree:</label>
            <input 
              type="text" 
              required 
              value={degree}
              onChange={(e) => setDegree(e.target.value)}
            />
            <label>Field of study:</label>
            <input 
              type="text" 
              required 
              value={fieldOfStudy}
              onChange={(e) => setFieldOfStudy(e.target.value)}
            />
            <label>Start date:</label>
            <input 
              type="date" 
              required 
              value={eduStartDate}
              onChange={(e) => setEduStartDate(e.target.value)}
            />
            <label>End date:</label>
            <input 
              type="date"  
              value={eduEndDate}
              onChange={(e) => setEduEndDate(e.target.value)}
            />

            <p className="form--headers">Work experience:</p>
            <label>Company:</label>
            <input 
              type="text" 
              required 
              value={company}
              onChange={(e) => setCompany(e.target.value)}
            />
            <label>Position:</label>
            <input 
              type="text" 
              required 
              value={position}
              onChange={(e) => setPosition(e.target.value)}
            />
            <label>Start date:</label>
            <input 
              type="date" 
              required 
              value={workStartDate}
              onChange={(e) => setWorkStartDate(e.target.value)}
            />
            <label>End date:</label>
            <input 
              type="date" 
              required 
              value={workEndDate}
              onChange={(e) => setWorkEndDate(e.target.value)}
            />
            <label>Description:</label>
            <textarea
              required
              value={description}
              onChange={(e) => setDescription(e.target.value)}
            ></textarea>

             <p className="form--headers">Certificate:</p>
            <label>Certificate name:</label>
            <input 
              type="text" 
              required 
              value={certName}
              onChange={(e) => setCertName(e.target.value)}
            />
            <label>Organization:</label>
            <input 
              type="text" 
              required 
              value={organization}
              onChange={(e) => setOrganization(e.target.value)}
            />
            <label>Issue date:</label>
            <input 
              type="date" 
              required 
              value={issueDate}
              onChange={(e) => setIssueDate(e.target.value)}
            />
            <label>Expiration date:</label>
            <input 
              type="date" 
              required 
              value={expirationDate}
              onChange={(e) => setExpirationDate(e.target.value)}
            />
            < p className="form--headers">Languages:</p>
            <label>Languages 1:</label>
            <input 
              type="text" 
              value={language1}
              onChange={(e) => setLanguage1(e.target.value)}
            />
            <label>Proficiency Level:</label>
            <input 
              type="text" 
              placeholder="of the first language"
              value={level1}
              onChange={(e) => setLevel1(e.target.value)}
            />
            <label>Languages 2:</label>
            <input 
              type="text" 
              value={language2}
              onChange={(e) => setLanguage2(e.target.value)}
            />
            <label>Proficiency Level:</label>
            <input 
              type="text" 
              placeholder="of the second language"
              value={level2}
              onChange={(e) => setLevel2(e.target.value)}
            />
            < p className="form--headers">Others:</p>
            <label>Skills:</label>
            <input 
              type="text" 
              placeholder="first skill"
              value={skill1}
              onChange={(e) => setSkill1(e.target.value)}
            />
            <br></br>
            <input 
              type="text" 
              placeholder="second skill"
              value={skill2}
              onChange={(e) => setSkill2(e.target.value)}
            />
            <br></br>
            <input 
              type="text" 
              placeholder="third skill"
              value={skill3}
              onChange={(e) => setSkill3(e.target.value)}
            />

              <label>Headline:</label>
              <textarea
                required
                value={headline}
                onChange={(e) => setHeadline(e.target.value)}
              ></textarea>     
              <div className="buttonWrapepr">
                 <button onClick = {()=>handleDownloadPDF()} disabled={!(loader===false)}>Create CV</button>
              </div>
            
          </form>
        </div>
        <div className="cv-wrapper">
          <div className="cv">
            <div className="personalInfo-wrapper">
              <p className="personalInfo-wrapper--name">{name}</p>
              <div className="addressAndEmail--wrapper">
                  <p className="addressText">{address}</p>
                  <div className="emailAndPhone">
                    <p className="emailAndPhoneText">Email: {email}</p>
                    <p className="emailAndPhoneText">Phone: {phone}</p>
                  </div>
              </div>
            </div>
            <div className="hr"></div>
            <div className="headlineWrapper"><p className="headline">{headline}</p></div>
              <div className="hr"></div>
            <div className="side-others">
              <div className="main-wrapper">
                    <div className="side-wrapper">
                      <div className="side">
                        <p className="sideText">{institute}</p>
                      </div>
                    </div>
                    <div className="innerMainMain">
                      <p className="section-header">Education:</p>
                      <p className="section-text">Degree: {degree}</p>
                      <p className="section-text">Field of study: {fieldOfStudy}</p>
                      <p className="section-text">Duration: {eduStartDate} - {eduEndDate}</p>
                    </div>
              </div>
              <div className="main-wrapper">
                    <div className="side-wrapper">
                      <div className="side">
                        <p className="sideText">{company}</p>
                      </div>
                    </div>
                    <div className="innerMainMain">
                        <p className="section-header">Working Experience:</p>
                        <p className="section-text">Position: {position}</p>
                        <p className="section-text">Duration: {workStartDate} - {workEndDate}</p>
                        <p className="section-text">{description}</p>
                    </div>
              </div>
              <div className="main-wrapper">
                    <div className="side-wrapper">
                      <div className="side">
                        <p className="sideText">{organization}</p>
                      </div>
                    </div>
                    <div className="innerMainMain">
                        <p className="section-header">Certificates:</p>
                        <p className="section-text">Certificate name: {certName}</p>
                        <p className="section-text">Issue date: {issueDate}</p>
                        <p className="section-text">Valid till: {expirationDate}</p>
                    </div>
              </div>
              <div className="main-wrapper">
              <div className="side-wrapper">
                    <div className="side">
                        <p className="sideText">Others:</p>
                      </div>
                    </div>
                    <div className="innerMainMain">
                        <p className="section-header">Languages:</p>
                        <p className="section-text">{language1} - level: {level1}</p>
                        <p className="section-text">{language2} - level: {level2}</p>
                        <p className="section-header">Skills:</p>
                        <p className="section-text">{skill1},  {skill2},  {skill3}</p>
                    </div>
              </div>
              <br></br><br></br>  
              <div className="main-wrapper">           
              </div>
            </div>   
          </div>
        </div>
    </div>
  );
}
 
export default Create;