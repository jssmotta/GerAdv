import React from 'react';
import { render } from '@testing-library/react';
import ViaRecebimentoIncContainer from '@/app/GerAdv_TS/ViaRecebimento/Components/ViaRecebimentoIncContainer';
// ViaRecebimentoIncContainer.test.tsx
// Mock do ViaRecebimentoInc
jest.mock('@/app/GerAdv_TS/ViaRecebimento/Crud/Inc/ViaRecebimento', () => (props: any) => (
<div data-testid='viarecebimento-inc-mock' {...props} />
));
describe('ViaRecebimentoIncContainer', () => {
  it('deve renderizar ViaRecebimentoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ViaRecebimentoIncContainer id={id} navigator={mockNavigator} />
  );
  const viarecebimentoInc = getByTestId('viarecebimento-inc-mock');
  expect(viarecebimentoInc).toBeInTheDocument();
  expect(viarecebimentoInc.getAttribute('id')).toBe(id.toString());

});
});