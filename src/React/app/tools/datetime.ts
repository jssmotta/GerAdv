export const dataBrazil = (date: Date): string => {
  try {
    const offset = -3 * 60; // GMT-3
    const localDate = new Date(date.getTime() + offset * 60 * 1000);
    return localDate.toISOString().slice(0, 19) + '-03:00';
  } catch (error) {
    console.log('Erro ao formatar data');
    return '';
  }
};

export const dataComHora = (data: Date): string => {
  try {
    const day = data.getDate().toString().padStart(2, '0');
    const month = (data.getMonth() + 1).toString().padStart(2, '0'); // Months are zero-based
    const year = data.getFullYear();
    const hours = data.getHours().toString().padStart(2, '0');
    const minutes = data.getMinutes().toString().padStart(2, '0');
    const seconds = data.getSeconds().toString().padStart(2, '0');
    return `${day}/${month}/${year} ${hours}:${minutes}:${seconds}`;
  } catch (error) {
    console.log('Erro ao formatar data com hora');
    return '';
  }
};

export const toDataHora = (dataStr: string): Date => {
  let date: Date;

  if (dataStr.includes('T')) {
    // ISO format
    date = new Date(dataStr);
  } else if (dataStr.includes('/')) {
    // DD/MM/YYYY or DD/MM/YYYY HH:mm:ss format
    const [datePart, timePart] = dataStr.split(' ');
    const [day, month, year] = datePart.split('/').map(Number);
    let hours = 0,
      minutes = 0,
      seconds = 0;
    if (timePart) {
      [hours, minutes, seconds] = timePart.split(':').map(Number);
    }
    date = new Date(year, month - 1, day, hours, minutes, seconds);
  } else if (dataStr.includes(':')) {
    // HH:mm format
    const [hours, minutes] = dataStr.split(':').map(Number);
    const now = new Date();
    date = new Date(
      now.getFullYear(),
      now.getMonth(),
      now.getDate(),
      hours,
      minutes
    );
  } else {
    //console.log(dataStr, 'Invalid date format' );
    date = new Date();
  }

  return date;
};

export const isValidDate = (
  date: string | Date | null | undefined
): boolean => {
  return date instanceof Date && !isNaN(date.getTime());
};

export const formatDate = (date: Date): string => {
  const day = String(date.getDate()).padStart(2, '0');
  const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are zero-based
  const year = date.getFullYear();
  return `${day}-${month}-${year}`;
};
