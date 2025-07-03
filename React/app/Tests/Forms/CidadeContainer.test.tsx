import React from 'react';
import { render } from '@testing-library/react';
import CidadeIncContainer from '@/app/GerAdv_TS/Cidade/Components/CidadeIncContainer';
// CidadeIncContainer.test.tsx
// Mock do CidadeInc
jest.mock('@/app/GerAdv_TS/Cidade/Crud/Inc/Cidade', () => (props: any) => (
<div data-testid='cidade-inc-mock' {...props} />
));
describe('CidadeIncContainer', () => {
  it('deve renderizar CidadeInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <CidadeIncContainer id={id} navigator={mockNavigator} />
  );
  const cidadeInc = getByTestId('cidade-inc-mock');
  expect(cidadeInc).toBeInTheDocument();
  expect(cidadeInc.getAttribute('id')).toBe(id.toString());

});
});