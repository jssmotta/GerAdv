export function ProntuarioZero() {
    return process.env.NEXT_PUBLIC_PRONTUARIO_ZERO === '0' ? 0 : Number(process.env.NEXT_PUBLIC_PRONTUARIO_ZERO);
}