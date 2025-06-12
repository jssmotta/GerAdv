'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import NECompromissosInc from '../Crud/Inc/NECompromissos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface NECompromissosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const NECompromissosIncContainer: React.FC<NECompromissosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <NECompromissosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default NECompromissosIncContainer;