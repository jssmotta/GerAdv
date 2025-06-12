'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaStatusInc from '../Crud/Inc/AgendaStatus';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaStatusIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AgendaStatusIncContainer: React.FC<AgendaStatusIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AgendaStatusInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AgendaStatusIncContainer;