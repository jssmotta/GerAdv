'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import UFInc from '../Crud/Inc/UF';
import { getParamFromUrl } from '@/app/tools/helpers';
interface UFIncContainerProps {
  id: number;
  navigator: INavigator;
}
const UFIncContainer: React.FC<UFIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <UFInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default UFIncContainer;