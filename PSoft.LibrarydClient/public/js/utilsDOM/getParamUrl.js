export const getParamURL = (name) =>
  decodeURIComponent(
    (new RegExp("[?|&]" + name + "=" + "([^&;]+?)(&|#|;|$)").exec(
      location.search
    ) || [, ""])[1].replace(/\+/g, "%20")
  ) || null;
