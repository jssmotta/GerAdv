'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OperadorGruposAgendaOperadoresInc from '../Crud/Inc/OperadorGruposAgendaOperadores';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OperadorGruposAgendaOperadoresIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const OperadorGruposAgendaOperadoresIncContainer: React.FC<OperadorGruposAgendaOperadoresIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <OperadorGruposAgendaOperadoresInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default OperadorGruposAgendaOperadoresIncContainer;