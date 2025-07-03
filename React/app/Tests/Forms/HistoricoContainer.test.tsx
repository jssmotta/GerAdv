import React from 'react';
import { render } from '@testing-library/react';
import HistoricoIncContainer from '@/app/GerAdv_TS/Historico/Components/HistoricoIncContainer';
// HistoricoIncContainer.test.tsx
// Mock do HistoricoInc
jest.mock('@/app/GerAdv_TS/Historico/Crud/Inc/Historico', () => (props: any) => (
<div data-testid='historico-inc-mock' {...props} />
));
describe('HistoricoIncContainer', () => {
  it('deve renderizar HistoricoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <HistoricoIncContainer id={id} navigator={mockNavigator} />
  );
  const historicoInc = getByTestId('historico-inc-mock');
  expect(historicoInc).toBeInTheDocument();
  expect(historicoInc.getAttribute('id')).toBe(id.toString());

});
});