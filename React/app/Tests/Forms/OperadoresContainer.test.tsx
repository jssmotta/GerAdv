import React from 'react';
import { render } from '@testing-library/react';
import OperadoresIncContainer from '@/app/GerAdv_TS/Operadores/Components/OperadoresIncContainer';
// OperadoresIncContainer.test.tsx
// Mock do OperadoresInc
jest.mock('@/app/GerAdv_TS/Operadores/Crud/Inc/Operadores', () => (props: any) => (
<div data-testid='operadores-inc-mock' {...props} />
));
describe('OperadoresIncContainer', () => {
  it('deve renderizar OperadoresInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <OperadoresIncContainer id={id} navigator={mockNavigator} />
  );
  const operadoresInc = getByTestId('operadores-inc-mock');
  expect(operadoresInc).toBeInTheDocument();
  expect(operadoresInc.getAttribute('id')).toBe(id.toString());

});
});