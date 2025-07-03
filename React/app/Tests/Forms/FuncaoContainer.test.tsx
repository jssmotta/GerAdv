import React from 'react';
import { render } from '@testing-library/react';
import FuncaoIncContainer from '@/app/GerAdv_TS/Funcao/Components/FuncaoIncContainer';
// FuncaoIncContainer.test.tsx
// Mock do FuncaoInc
jest.mock('@/app/GerAdv_TS/Funcao/Crud/Inc/Funcao', () => (props: any) => (
<div data-testid='funcao-inc-mock' {...props} />
));
describe('FuncaoIncContainer', () => {
  it('deve renderizar FuncaoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <FuncaoIncContainer id={id} navigator={mockNavigator} />
  );
  const funcaoInc = getByTestId('funcao-inc-mock');
  expect(funcaoInc).toBeInTheDocument();
  expect(funcaoInc.getAttribute('id')).toBe(id.toString());

});
});