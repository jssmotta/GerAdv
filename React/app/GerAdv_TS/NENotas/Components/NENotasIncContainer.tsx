'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import NENotasInc from '../Crud/Inc/NENotas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface NENotasIncContainerProps {
  id: number;
  navigator: INavigator;
}
const NENotasIncContainer: React.FC<NENotasIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <NENotasInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default NENotasIncContainer;