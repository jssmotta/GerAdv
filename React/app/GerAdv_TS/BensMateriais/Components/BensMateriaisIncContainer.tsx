'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import BensMateriaisInc from '../Crud/Inc/BensMateriais';
import { getParamFromUrl } from '@/app/tools/helpers';
interface BensMateriaisIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const BensMateriaisIncContainer: React.FC<BensMateriaisIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <BensMateriaisInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default BensMateriaisIncContainer;