import React from 'react';
import { render } from '@testing-library/react';
import OperadorEMailPopupIncContainer from '@/app/GerAdv_TS/OperadorEMailPopup/Components/OperadorEMailPopupIncContainer';
// OperadorEMailPopupIncContainer.test.tsx
// Mock do OperadorEMailPopupInc
jest.mock('@/app/GerAdv_TS/OperadorEMailPopup/Crud/Inc/OperadorEMailPopup', () => (props: any) => (
<div data-testid='operadoremailpopup-inc-mock' {...props} />
));
describe('OperadorEMailPopupIncContainer', () => {
  it('deve renderizar OperadorEMailPopupInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <OperadorEMailPopupIncContainer id={id} navigator={mockNavigator} />
  );
  const operadoremailpopupInc = getByTestId('operadoremailpopup-inc-mock');
  expect(operadoremailpopupInc).toBeInTheDocument();
  expect(operadoremailpopupInc.getAttribute('id')).toBe(id.toString());

});
});