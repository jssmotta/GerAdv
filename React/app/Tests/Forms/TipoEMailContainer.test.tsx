import React from 'react';
import { render } from '@testing-library/react';
import TipoEMailIncContainer from '@/app/GerAdv_TS/TipoEMail/Components/TipoEMailIncContainer';
// TipoEMailIncContainer.test.tsx
// Mock do TipoEMailInc
jest.mock('@/app/GerAdv_TS/TipoEMail/Crud/Inc/TipoEMail', () => (props: any) => (
<div data-testid='tipoemail-inc-mock' {...props} />
));
describe('TipoEMailIncContainer', () => {
  it('deve renderizar TipoEMailInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <TipoEMailIncContainer id={id} navigator={mockNavigator} />
  );
  const tipoemailInc = getByTestId('tipoemail-inc-mock');
  expect(tipoemailInc).toBeInTheDocument();
  expect(tipoemailInc.getAttribute('id')).toBe(id.toString());

});
});