import React from 'react';

export const Error = () => {
  return (
    <div
      style={{
        position: 'absolute',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'column',
        width: '100%',
        height: '100%',
      }}>
      <h1>Ты не должен быть здесь</h1>
      <img
        src="https://media.tenor.com/M0YyxTY9gB0AAAAC/%D1%81%D0%BA%D0%B0%D0%BB%D0%B0.gif"
        alt=""
      />
      <button onClick={() => alert('прохладно!')}>Ладно</button>
    </div>
  );
};
