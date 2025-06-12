'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import Diario2Inc from '../Crud/Inc/Diario2';
import { getParamFromUrl } from '@/app/tools/helpers';
interface Diario2IncContainerProps {
  id: number;
  navigator: INavigator;
}
const Diario2IncContainer: React.FC<Diario2IncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <Diario2Inc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default Diario2IncContainer;