'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaRepetirInc from '../Crud/Inc/AgendaRepetir';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaRepetirIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AgendaRepetirIncContainer: React.FC<AgendaRepetirIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AgendaRepetirInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AgendaRepetirIncContainer;