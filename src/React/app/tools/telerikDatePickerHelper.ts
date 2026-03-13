import { format } from 'date-fns-tz';

export const gravaDatePicker = (dataString: string): string => {
  try {
    // Parse a string da data
    const data = new Date(dataString);

    const datePattern = /^(\d{2})\/(\d{2})\/(\d{4})$/;
    const match = dataString.match(datePattern);
    if (match) {
      return dataString;
    }

    if (isNaN(data.getTime())) {
      //throw new Error('Data inválida');
      return new Date().toISOString();
    }

    // Formata para yyyy-MM-dd
    return format(data, 'yyyy-MM-dd');
  } catch {
    // throw new Error('Data inválida');
    return new Date().toISOString();
  }
};

export const setDatePicker = (dataStr: string): Date => {
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
    console.log(dataStr, 'Invalid date format');
    date = new Date();
  }

  return date;
};
