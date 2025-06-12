'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import EventoPrazoAgendaInc from '../Crud/Inc/EventoPrazoAgenda';
import { getParamFromUrl } from '@/app/tools/helpers';
interface EventoPrazoAgendaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const EventoPrazoAgendaIncContainer: React.FC<EventoPrazoAgendaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <EventoPrazoAgendaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default EventoPrazoAgendaIncContainer;