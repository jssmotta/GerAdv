import React from 'react';
import { render } from '@testing-library/react';
import AndamentosMDIncContainer from '@/app/GerAdv_TS/AndamentosMD/Components/AndamentosMDIncContainer';
// AndamentosMDIncContainer.test.tsx
// Mock do AndamentosMDInc
jest.mock('@/app/GerAdv_TS/AndamentosMD/Crud/Inc/AndamentosMD', () => (props: any) => (
<div data-testid='andamentosmd-inc-mock' {...props} />
));
describe('AndamentosMDIncContainer', () => {
  it('deve renderizar AndamentosMDInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AndamentosMDIncContainer id={id} navigator={mockNavigator} />
  );
  const andamentosmdInc = getByTestId('andamentosmd-inc-mock');
  expect(andamentosmdInc).toBeInTheDocument();
  expect(andamentosmdInc.getAttribute('id')).toBe(id.toString());

});
});