import React, { useState } from "react";
import { Link } from "react-router-dom";
import { Icon } from "../Icon";
import { Input } from "../Input/Input";
import { Modal } from "../Modal/Modal";

import styles from "./Avatar.module.css";

type Props = {
  image?: string;
  link?: string;
  onAuth?: () => void;
};

export const Avatar: React.FC<Props> = ({ image, link, onAuth }) => {
  return (
    <div className={styles.Avatar} onClick={onAuth}>
      {!!image ? (
        <img src={image} className={styles.Image} alt="" />
      ) : (
        <Icon name="user" fill="#212429" />
      )}
      {!!link && <Link to={link} className={styles.Link} />}

      {!authModal && (
        <Modal
          onClose={() => {
            console.log("пошел нахуй");
            setAuthModal(false);
          }}
          title="Войти в профиль"
        >
          <Input icon="user" placeholder="email" />
          <Input icon="close" placeholder="password" />
        </Modal>
      )}
    </div>
  );
};
