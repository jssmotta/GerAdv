'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import Agenda2AgendaInc from '../Crud/Inc/Agenda2Agenda';
import { getParamFromUrl } from '@/app/tools/helpers';
interface Agenda2AgendaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const Agenda2AgendaIncContainer: React.FC<Agenda2AgendaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <Agenda2AgendaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default Agenda2AgendaIncContainer;