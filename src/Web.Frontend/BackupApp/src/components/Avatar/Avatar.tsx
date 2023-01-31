import React from "react";
import { Link } from "react-router-dom";
import { Icon } from "../Icon";

import styles from "./Avatar.module.css";

type Props = {
  image?: string;
  link?: string;
};

export const Avatar: React.FC<Props> = ({ image, link }) => {
  const handleAuthModal = () => {};

  return (
    <div className={styles.Avatar} onClick={handleAuthModal}>
      {!!image ? (
        <img src={image} className={styles.Image} alt="" />
      ) : (
        <Icon name="user" fill="#212429" />
      )}
      {!!link && <Link to={link} className={styles.Link} />}
    </div>
  );
};
