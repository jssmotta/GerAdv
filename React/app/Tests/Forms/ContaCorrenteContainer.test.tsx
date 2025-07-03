import React from 'react';
import { render } from '@testing-library/react';
import ContaCorrenteIncContainer from '@/app/GerAdv_TS/ContaCorrente/Components/ContaCorrenteIncContainer';
// ContaCorrenteIncContainer.test.tsx
// Mock do ContaCorrenteInc
jest.mock('@/app/GerAdv_TS/ContaCorrente/Crud/Inc/ContaCorrente', () => (props: any) => (
<div data-testid='contacorrente-inc-mock' {...props} />
));
describe('ContaCorrenteIncContainer', () => {
  it('deve renderizar ContaCorrenteInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ContaCorrenteIncContainer id={id} navigator={mockNavigator} />
  );
  const contacorrenteInc = getByTestId('contacorrente-inc-mock');
  expect(contacorrenteInc).toBeInTheDocument();
  expect(contacorrenteInc.getAttribute('id')).toBe(id.toString());

});
});