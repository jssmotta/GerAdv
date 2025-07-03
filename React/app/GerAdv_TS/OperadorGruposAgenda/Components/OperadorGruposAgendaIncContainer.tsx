'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OperadorGruposAgendaInc from '../Crud/Inc/OperadorGruposAgenda';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OperadorGruposAgendaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const OperadorGruposAgendaIncContainer: React.FC<OperadorGruposAgendaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <OperadorGruposAgendaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default OperadorGruposAgendaIncContainer;