'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import EndTitInc from '../Crud/Inc/EndTit';
import { getParamFromUrl } from '@/app/tools/helpers';
interface EndTitIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const EndTitIncContainer: React.FC<EndTitIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <EndTitInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default EndTitIncContainer;