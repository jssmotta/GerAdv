'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OponentesRepLegalInc from '../Crud/Inc/OponentesRepLegal';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OponentesRepLegalIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const OponentesRepLegalIncContainer: React.FC<OponentesRepLegalIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <OponentesRepLegalInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default OponentesRepLegalIncContainer;