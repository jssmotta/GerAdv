'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OperadorGruposAgendaInc from '../Crud/Inc/OperadorGruposAgenda';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OperadorGruposAgendaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const OperadorGruposAgendaIncContainer: React.FC<OperadorGruposAgendaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <OperadorGruposAgendaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default OperadorGruposAgendaIncContainer;