import React, { useState } from "react";
import { groupWords } from "../../utils/groupWords";
import { Input } from "../Input/Input";
import { Modal } from "../Modal/Modal";

import styles from "./Logo.module.css";

export const Logo = () => {
  const [citySelect, setCitySelect] = useState(false);

  const handleSelectCity = () => setCitySelect(true);

  const cities = groupWords([
    "Йошкар-Ола",
    "Москва",
    "Санкт-петербург",
    "Казань",
    "Краснодар",
    "Абакан",
  ]);

  return (
    <div className={styles.Logo}>
      <h1 className={styles.Title}>Афишер</h1>
      <span className={styles.City} onClick={handleSelectCity}>
        Москва
      </span>

      {citySelect && (
        <Modal title="Выберите город" onClose={() => setCitySelect(false)}>
          <Input icon="search" placeholder="Москва" />
          {JSON.stringify(cities)}
        </Modal>
      )}
    </div>
  );
};
