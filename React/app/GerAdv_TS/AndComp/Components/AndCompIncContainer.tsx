'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AndCompInc from '../Crud/Inc/AndComp';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AndCompIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AndCompIncContainer: React.FC<AndCompIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AndCompInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AndCompIncContainer;