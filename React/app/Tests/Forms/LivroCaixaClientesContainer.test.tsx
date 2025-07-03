import React from 'react';
import { render } from '@testing-library/react';
import LivroCaixaClientesIncContainer from '@/app/GerAdv_TS/LivroCaixaClientes/Components/LivroCaixaClientesIncContainer';
// LivroCaixaClientesIncContainer.test.tsx
// Mock do LivroCaixaClientesInc
jest.mock('@/app/GerAdv_TS/LivroCaixaClientes/Crud/Inc/LivroCaixaClientes', () => (props: any) => (
<div data-testid='livrocaixaclientes-inc-mock' {...props} />
));
describe('LivroCaixaClientesIncContainer', () => {
  it('deve renderizar LivroCaixaClientesInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <LivroCaixaClientesIncContainer id={id} navigator={mockNavigator} />
  );
  const livrocaixaclientesInc = getByTestId('livrocaixaclientes-inc-mock');
  expect(livrocaixaclientesInc).toBeInTheDocument();
  expect(livrocaixaclientesInc.getAttribute('id')).toBe(id.toString());

});
});