import React from 'react';
import styles from './Header.module.css'
import myImage from '../myImage/unnamed.png';

function Header() {
    return (
    <div className = {styles.container}>
    <div className = {styles.left}>
    <p className={styles.heading}>
    A <span>Resume</span> that stands out!
    </p>
    <p className={styles.heading}>
    Create and customize your Cv <span>It's absolutely free</span>
    </p>
    </div>
    <div className={styles.right}>
      <img src={myImage} alt = 'Resume' />
    </div>
    </div>
  );
}

export default Header;