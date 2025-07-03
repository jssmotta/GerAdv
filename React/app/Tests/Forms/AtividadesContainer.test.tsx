import React from 'react';
import { render } from '@testing-library/react';
import AtividadesIncContainer from '@/app/GerAdv_TS/Atividades/Components/AtividadesIncContainer';
// AtividadesIncContainer.test.tsx
// Mock do AtividadesInc
jest.mock('@/app/GerAdv_TS/Atividades/Crud/Inc/Atividades', () => (props: any) => (
<div data-testid='atividades-inc-mock' {...props} />
));
describe('AtividadesIncContainer', () => {
  it('deve renderizar AtividadesInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AtividadesIncContainer id={id} navigator={mockNavigator} />
  );
  const atividadesInc = getByTestId('atividades-inc-mock');
  expect(atividadesInc).toBeInTheDocument();
  expect(atividadesInc.getAttribute('id')).toBe(id.toString());

});
});