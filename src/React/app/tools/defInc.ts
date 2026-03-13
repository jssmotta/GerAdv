import { getParamFromUrl } from './helpers';

export const PHeightWindow = 365;
export const PWidthWindow = 520;

export function getParamId(): number {
  return getParamFromUrl('id');
}
