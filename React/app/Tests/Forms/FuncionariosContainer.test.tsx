import React from 'react';
import { render } from '@testing-library/react';
import FuncionariosIncContainer from '@/app/GerAdv_TS/Funcionarios/Components/FuncionariosIncContainer';
// FuncionariosIncContainer.test.tsx
// Mock do FuncionariosInc
jest.mock('@/app/GerAdv_TS/Funcionarios/Crud/Inc/Funcionarios', () => (props: any) => (
<div data-testid='funcionarios-inc-mock' {...props} />
));
describe('FuncionariosIncContainer', () => {
  it('deve renderizar FuncionariosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <FuncionariosIncContainer id={id} navigator={mockNavigator} />
  );
  const funcionariosInc = getByTestId('funcionarios-inc-mock');
  expect(funcionariosInc).toBeInTheDocument();
  expect(funcionariosInc.getAttribute('id')).toBe(id.toString());

});
});