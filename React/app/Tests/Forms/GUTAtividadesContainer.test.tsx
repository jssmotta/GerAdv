import React from 'react';
import { render } from '@testing-library/react';
import GUTAtividadesIncContainer from '@/app/GerAdv_TS/GUTAtividades/Components/GUTAtividadesIncContainer';
// GUTAtividadesIncContainer.test.tsx
// Mock do GUTAtividadesInc
jest.mock('@/app/GerAdv_TS/GUTAtividades/Crud/Inc/GUTAtividades', () => (props: any) => (
<div data-testid='gutatividades-inc-mock' {...props} />
));
describe('GUTAtividadesIncContainer', () => {
  it('deve renderizar GUTAtividadesInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <GUTAtividadesIncContainer id={id} navigator={mockNavigator} />
  );
  const gutatividadesInc = getByTestId('gutatividades-inc-mock');
  expect(gutatividadesInc).toBeInTheDocument();
  expect(gutatividadesInc.getAttribute('id')).toBe(id.toString());

});
});