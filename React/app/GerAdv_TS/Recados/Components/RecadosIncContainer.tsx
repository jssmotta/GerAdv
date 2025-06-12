'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import RecadosInc from '../Crud/Inc/Recados';
import { getParamFromUrl } from '@/app/tools/helpers';
interface RecadosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const RecadosIncContainer: React.FC<RecadosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <RecadosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default RecadosIncContainer;