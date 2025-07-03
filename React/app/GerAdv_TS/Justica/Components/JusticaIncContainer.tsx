'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import JusticaInc from '../Crud/Inc/Justica';
import { getParamFromUrl } from '@/app/tools/helpers';
interface JusticaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const JusticaIncContainer: React.FC<JusticaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <JusticaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default JusticaIncContainer;