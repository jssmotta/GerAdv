// Helper to parse pt-BR dates and produce a human-friendly Portuguese relative date.
export const parsePtBrDate = (str: string): Date | null => {
  if (!str) return null;
  const s = str.trim();

  // Try DD/MM/YYYY[ HH:MM[:SS]] first (pt-BR)
  const m = s.match(/^(\d{1,2})\/(\d{1,2})\/(\d{4})(?:\s+(\d{1,2}):(\d{2})(?::(\d{2}))?)?$/);
  if (m) {
    const day = parseInt(m[1], 10);
    const month = parseInt(m[2], 10) - 1;
    const year = parseInt(m[3], 10);
    const hour = m[4] ? parseInt(m[4], 10) : 0;
    const min = m[5] ? parseInt(m[5], 10) : 0;
    const sec = m[6] ? parseInt(m[6], 10) : 0;
    const d = new Date(year, month, day, hour, min, sec);
    if (d && d.getFullYear() === year && d.getMonth() === month && d.getDate() === day) return d;
  }

  // Fallback: try ISO / Date parse
  const iso = new Date(s);
  if (!isNaN(iso.getTime())) return iso;

  return null;
};

// QuandoSoft: dateStr optional, now optional for testing. Returns pt-BR relative text.
export const QuandoSoft = (dateStr?: string, nowParam?: Date): string => {
  if (!dateStr) return '';
  const d = parsePtBrDate(dateStr);
  if (!d) return '';

  const now = nowParam ?? new Date();
  const startOfDay = (dt: Date) => new Date(dt.getFullYear(), dt.getMonth(), dt.getDate());
  const a = startOfDay(d);
  const b = startOfDay(now);
  const diffMs = b.getTime() - a.getTime();
  if (diffMs < 0) return '';
  const totalDays = Math.floor(diffMs / (1000 * 60 * 60 * 24));

  if (totalDays === 0) return 'Hoje';
  if (totalDays === 1) return 'Ontem';

  // Calendar-based difference
  let years = now.getFullYear() - d.getFullYear();
  let months = now.getMonth() - d.getMonth();
  let days = now.getDate() - d.getDate();

  if (days < 0) {
    const prevMonth = new Date(now.getFullYear(), now.getMonth(), 0);
    days += prevMonth.getDate();
    months -= 1;
  }

  if (months < 0) {
    months += 12;
    years -= 1;
  }

  if (years > 0) {
    if (months === 0) return years === 1 ? 'Há 1 ano' : `Há ${years} anos`;
    return years === 1
      ? `Há 1 ano e ${months} ${months === 1 ? 'mês' : 'meses'}`
      : `Há ${years} anos e ${months} ${months === 1 ? 'mês' : 'meses'}`;
  }

  if (months > 0) {
    if (days === 0) return months === 1 ? 'Há 1 mês' : `Há ${months} meses`;
    return months === 1
      ? `Há 1 mês e ${days} ${days === 1 ? 'dia' : 'dias'}`
      : `Há ${months} meses e ${days} ${days === 1 ? 'dia' : 'dias'}`;
  }

  return `Há ${totalDays} ${totalDays === 1 ? 'dia' : 'dias'}`;
};

export default QuandoSoft;
