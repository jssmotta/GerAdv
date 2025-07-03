'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import UFInc from '../Crud/Inc/UF';
import { getParamFromUrl } from '@/app/tools/helpers';
interface UFIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const UFIncContainer: React.FC<UFIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <UFInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default UFIncContainer;