import React from 'react';
import { render } from '@testing-library/react';
import ProDepositosIncContainer from '@/app/GerAdv_TS/ProDepositos/Components/ProDepositosIncContainer';
// ProDepositosIncContainer.test.tsx
// Mock do ProDepositosInc
jest.mock('@/app/GerAdv_TS/ProDepositos/Crud/Inc/ProDepositos', () => (props: any) => (
<div data-testid='prodepositos-inc-mock' {...props} />
));
describe('ProDepositosIncContainer', () => {
  it('deve renderizar ProDepositosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ProDepositosIncContainer id={id} navigator={mockNavigator} />
  );
  const prodepositosInc = getByTestId('prodepositos-inc-mock');
  expect(prodepositosInc).toBeInTheDocument();
  expect(prodepositosInc.getAttribute('id')).toBe(id.toString());

});
});