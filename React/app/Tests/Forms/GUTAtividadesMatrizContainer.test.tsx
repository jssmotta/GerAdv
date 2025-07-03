import React from 'react';
import { render } from '@testing-library/react';
import GUTAtividadesMatrizIncContainer from '@/app/GerAdv_TS/GUTAtividadesMatriz/Components/GUTAtividadesMatrizIncContainer';
// GUTAtividadesMatrizIncContainer.test.tsx
// Mock do GUTAtividadesMatrizInc
jest.mock('@/app/GerAdv_TS/GUTAtividadesMatriz/Crud/Inc/GUTAtividadesMatriz', () => (props: any) => (
<div data-testid='gutatividadesmatriz-inc-mock' {...props} />
));
describe('GUTAtividadesMatrizIncContainer', () => {
  it('deve renderizar GUTAtividadesMatrizInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <GUTAtividadesMatrizIncContainer id={id} navigator={mockNavigator} />
  );
  const gutatividadesmatrizInc = getByTestId('gutatividadesmatriz-inc-mock');
  expect(gutatividadesmatrizInc).toBeInTheDocument();
  expect(gutatividadesmatrizInc.getAttribute('id')).toBe(id.toString());

});
});