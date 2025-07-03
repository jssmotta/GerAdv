import React from 'react';
import { render } from '@testing-library/react';
import EnderecosIncContainer from '@/app/GerAdv_TS/Enderecos/Components/EnderecosIncContainer';
// EnderecosIncContainer.test.tsx
// Mock do EnderecosInc
jest.mock('@/app/GerAdv_TS/Enderecos/Crud/Inc/Enderecos', () => (props: any) => (
<div data-testid='enderecos-inc-mock' {...props} />
));
describe('EnderecosIncContainer', () => {
  it('deve renderizar EnderecosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <EnderecosIncContainer id={id} navigator={mockNavigator} />
  );
  const enderecosInc = getByTestId('enderecos-inc-mock');
  expect(enderecosInc).toBeInTheDocument();
  expect(enderecosInc.getAttribute('id')).toBe(id.toString());

});
});