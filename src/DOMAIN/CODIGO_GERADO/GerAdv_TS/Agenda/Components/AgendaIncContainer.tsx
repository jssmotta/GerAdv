'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaInc from '../Crud/Inc/Agenda';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AgendaIncContainer: React.FC<AgendaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AgendaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AgendaIncContainer;