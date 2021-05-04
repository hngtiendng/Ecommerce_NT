import React from "react";

export default function Login(props) {
  return (
    <div>
      {(localStorage.removeItem("user"), props.userManager.signoutRedirect())}
    </div>
  );
}
