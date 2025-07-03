import React from 'react';
import { render } from '@testing-library/react';
import LivroCaixaIncContainer from '@/app/GerAdv_TS/LivroCaixa/Components/LivroCaixaIncContainer';
// LivroCaixaIncContainer.test.tsx
// Mock do LivroCaixaInc
jest.mock('@/app/GerAdv_TS/LivroCaixa/Crud/Inc/LivroCaixa', () => (props: any) => (
<div data-testid='livrocaixa-inc-mock' {...props} />
));
describe('LivroCaixaIncContainer', () => {
  it('deve renderizar LivroCaixaInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <LivroCaixaIncContainer id={id} navigator={mockNavigator} />
  );
  const livrocaixaInc = getByTestId('livrocaixa-inc-mock');
  expect(livrocaixaInc).toBeInTheDocument();
  expect(livrocaixaInc.getAttribute('id')).toBe(id.toString());

});
});