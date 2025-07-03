import React from 'react';
import { render } from '@testing-library/react';
import ProObservacoesIncContainer from '@/app/GerAdv_TS/ProObservacoes/Components/ProObservacoesIncContainer';
// ProObservacoesIncContainer.test.tsx
// Mock do ProObservacoesInc
jest.mock('@/app/GerAdv_TS/ProObservacoes/Crud/Inc/ProObservacoes', () => (props: any) => (
<div data-testid='proobservacoes-inc-mock' {...props} />
));
describe('ProObservacoesIncContainer', () => {
  it('deve renderizar ProObservacoesInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ProObservacoesIncContainer id={id} navigator={mockNavigator} />
  );
  const proobservacoesInc = getByTestId('proobservacoes-inc-mock');
  expect(proobservacoesInc).toBeInTheDocument();
  expect(proobservacoesInc.getAttribute('id')).toBe(id.toString());

});
});