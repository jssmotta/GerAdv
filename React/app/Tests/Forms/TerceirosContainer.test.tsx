import React from 'react';
import { render } from '@testing-library/react';
import TerceirosIncContainer from '@/app/GerAdv_TS/Terceiros/Components/TerceirosIncContainer';
// TerceirosIncContainer.test.tsx
// Mock do TerceirosInc
jest.mock('@/app/GerAdv_TS/Terceiros/Crud/Inc/Terceiros', () => (props: any) => (
<div data-testid='terceiros-inc-mock' {...props} />
));
describe('TerceirosIncContainer', () => {
  it('deve renderizar TerceirosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <TerceirosIncContainer id={id} navigator={mockNavigator} />
  );
  const terceirosInc = getByTestId('terceiros-inc-mock');
  expect(terceirosInc).toBeInTheDocument();
  expect(terceirosInc.getAttribute('id')).toBe(id.toString());

});
});