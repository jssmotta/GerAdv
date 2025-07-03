'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AgendaRecordsInc from '../Crud/Inc/AgendaRecords';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AgendaRecordsIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const AgendaRecordsIncContainer: React.FC<AgendaRecordsIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <AgendaRecordsInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default AgendaRecordsIncContainer;