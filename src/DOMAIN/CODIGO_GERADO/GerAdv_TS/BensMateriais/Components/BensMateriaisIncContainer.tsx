'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import BensMateriaisInc from '../Crud/Inc/BensMateriais';
import { getParamFromUrl } from '@/app/tools/helpers';
interface BensMateriaisIncContainerProps {
  id: number;
  navigator: INavigator;
}
const BensMateriaisIncContainer: React.FC<BensMateriaisIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <BensMateriaisInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default BensMateriaisIncContainer;