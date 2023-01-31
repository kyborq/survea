import React, { useState } from "react";

import styles from "./Header.module.css";
import { Logo } from "../Logo/Logo";
import { Avatar } from "../Avatar/Avatar";
import { Button } from "../Button/Button";
import { Modal } from "../Modal/Modal";
import { Input } from "../Input/Input";
import { Map, YMaps } from "react-yandex-maps";
import { ThumbnailUploader } from "../ThumbnailUploader/ThumbnailUploader";

export const Header = () => {
  const [eventModal, setEventModal] = useState(false);

  return (
    <div className={styles.Header}>
      <div className={styles.Container}>
        <Logo />

        <div className={styles.Actions}>
          <div className={styles.Buttons}>
            <Button
              label="События"
              icon="addCircle"
              primary
              onClick={() => setEventModal(true)}
            />
            <Button icon="notification" />
          </div>

          <Avatar
            image="https://sun3.tele2-nn.userapi.com/impg/cJeNnCErOWnDQL2siPrlfLUm55D0gRqqHEhLmQ/THOmgW2zxH0.jpg?size=391x273&quality=96&sign=5dfaa96dbede2bab0048e78712d16d65&type=album"
            link="/user/kyborq"
          />
        </div>
      </div>

      {eventModal && (
        <Modal
          title="Новое событие"
          onClose={() => setEventModal(false)}
          onAccept={() => setEventModal(false)}
          onCancel={() => setEventModal(false)}
        >
          <ThumbnailUploader />
          <Input icon="info" placeholder="Название события" />
          <Input icon="info" placeholder="Описание события" />
          <Input icon="location" placeholder="Место проведения" />
          <div style={{ display: "flex", gap: 16 }}>
            <Input icon="calendar" placeholder="Дата" />
            <Input icon="clock" placeholder="Время" />
          </div>
        </Modal>
      )}
    </div>
  );
};
